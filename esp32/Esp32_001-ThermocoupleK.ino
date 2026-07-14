/****************************************************
 * Titre  : Gardien et moyen de contrôle
 * Date   : 10/02/2026
 * Auteur : Lordnel
 * But    : Ce programme lit les températures de trois
 *          thermocouples type K le long d'une barre
 *          métallique à l'aide de modules MAX6675 et
 *          d'un ESP32. Les mesures sont envoyées sur
 *          un serveur pour le monitoring des gradients
 *          thermiques.
 ****************************************************/

#include <max6675.h>
#include <WiFi.h>
#include <HTTPClient.h>
#include <WiFiClient.h>
#include <time.h>
#include <ArduinoJson.h>

// ================== Configuration broches ==================
#define PIN_SCK 19
#define PIN_SO 18

#define PIN_CS_1 5   // Position 1 (proche source chaude)
#define PIN_CS_2 12  // Position 2 (milieu)
#define PIN_CS_3 14  // Position 3 (extrémité)

// ================== Objets MAX6675 ==================
MAX6675 thermo1(PIN_SCK, PIN_CS_1, PIN_SO);
MAX6675 thermo2(PIN_SCK, PIN_CS_2, PIN_SO);
MAX6675 thermo3(PIN_SCK, PIN_CS_3, PIN_SO);

// ================= CONFIG =================
const char* ssid       = "HESTIM";
const char* password   = "Hestim@2022";

const char* API_BASE   = "http://172.16.1.37:8000"; // serveur FastAPI
const char* apiKey     = "ESP_SECRET";

#define READ_INTERVAL  1000
#define MAX_SENSORS    10

// NTP UTC
const long gmtOffset_sec = 0;
const int  daylightOffset_sec = 0;

const uint16_t HTTP_TIMEOUT_MS = 3000;

// ================= STRUCTURES =================
struct TempSensor {
  String name;
  float position;
  float temperature;
  bool ok;
};

TempSensor sensorList[MAX_SENSORS];
int sensorCount = 0;

unsigned long lastReadTime = 0;

static char payload[8192];

// Simulation id reçu du serveur
String simulationId = "";

// ================= UTILS =================
String jsonEscape(const String& in) {
  String out;
  out.reserve(in.length() + 4);
  for (size_t i = 0; i < in.length(); i++) {
    char c = in[i];
    if (c == '\"') out += "\\\"";
    else if (c == '\\') out += "\\\\";
    else out += c;
  }
  return out;
}

void ensureWiFi() {
  if (WiFi.status() == WL_CONNECTED) return;

  Serial.println("[WiFi] Reconnexion...");
  WiFi.disconnect();
  WiFi.begin(ssid, password);

  unsigned long start = millis();
  while (WiFi.status() != WL_CONNECTED && millis() - start < 7000) {
    delay(250);
    Serial.print(".");
  }
  Serial.println();

  if (WiFi.status() == WL_CONNECTED) {
    Serial.print("[WiFi] OK IP: ");
    Serial.println(WiFi.localIP());
  } else {
    Serial.println("[WiFi] Échec (timeout).");
  }
}

bool timeReady() {
  time_t now = time(nullptr);
  return (now > 1700000000);
}

uint32_t unixTimeSec() {
  return (uint32_t)time(nullptr);
}

// ================= HTTP HELPERS =================
String apiUrl(const char* path) {
  return String(API_BASE) + String(path);
}

// POST /simulation/start -> récupère simulation_id
bool startSimulation() {
  ensureWiFi();
  if (WiFi.status() != WL_CONNECTED) return false;
  if (!timeReady()) {
    Serial.println("[NTP] pas prêt, start simulation reporté.");
    return false;
  }

  HTTPClient http;
  WiFiClient client;

  String url = apiUrl("/simulation/start");
  http.begin(client, url);
  http.setTimeout(HTTP_TIMEOUT_MS);
  http.useHTTP10(true);
  http.setReuse(false); 
  http.addHeader("Content-Type", "application/json");
  http.addHeader("X-API-Key", apiKey);

  // L'ESP envoie juste infos (pas d'id)
  String payload = "{";
  payload += "\"name\":\"ThermalBench_Run\",";
  payload += "\"description\":\"Start from ESP8266\",";
  payload += "\"device\":\"ESP8266\"";
  payload += "}";

  int code = http.POST(payload);
  Serial.print("[HTTP] start code=");
  Serial.println(code);

  if (code <= 0) {
    http.end();
    client.stop();   // force fermeture socket
    delay(20);       // petite pause anti pbuf_free
    return false;
  }

  String resp = http.getString();
  http.end();
  client.stop();   // force fermeture socket
  delay(20);       // petite pause anti pbuf_free

  Serial.print("[HTTP] start resp=");
  Serial.println(resp);

  // Parse JSON response: {"status":"started","simulation_id":"SIM_..."}
  StaticJsonDocument<256> doc;
  DeserializationError err = deserializeJson(doc, resp);
  if (err) {
    Serial.print("[JSON] parse error: ");
    Serial.println(err.c_str());
    return false;
  }

  const char* sim = doc["simulation_id"];
  if (!sim || String(sim).length() == 0) return false;

  simulationId = String(sim);
  Serial.print("[SIM] active id=");
  Serial.println(simulationId);
  return true;
}

bool buildDataPayload(char* buffer, size_t maxLen, uint32_t tsSec) {
  int offset = 0;

  offset += snprintf(buffer + offset, maxLen - offset,
    "{"
    "\"simulation_id\":\"%s\","
    "\"timestamp\":%lu,"
    "\"sensors\":[",
    simulationId.c_str(),
    (unsigned long)tsSec
  );

  for (int i = 0; i < sensorCount; i++) {
    if (offset >= maxLen - 150) return false;  // sécurité overflow

    offset += snprintf(buffer + offset, maxLen - offset,
      "{"
      "\"name\":\"%s\","
      "\"temperature\":",
      sensorList[i].name.c_str()
    );

    if (!sensorList[i].ok) {
      offset += snprintf(buffer + offset, maxLen - offset, "null");
    } else {
      offset += snprintf(buffer + offset, maxLen - offset, "%.2f", sensorList[i].temperature);
    }

    offset += snprintf(buffer + offset, maxLen - offset,
      ",\"position\":%.2f}",
      sensorList[i].position
    );

    if (i < sensorCount - 1) {
      offset += snprintf(buffer + offset, maxLen - offset, ",");
    }
  }

  offset += snprintf(buffer + offset, maxLen - offset, "]}");

  return true;
}

void sendData() {
  if (simulationId.length() == 0) return;
  ensureWiFi();
  if (WiFi.status() != WL_CONNECTED) return;
  if (!timeReady()) return;

  memset(payload, 0, sizeof(payload));

  uint32_t tsSec = unixTimeSec();
  if (!buildDataPayload(payload, sizeof(payload), tsSec)) {
    Serial.println("[JSON] PAYLOAD OVERFLOW BLOCKED");
    return;
  }

  size_t len = strlen(payload);
  if (len == 0 || len >= sizeof(payload)) {
    Serial.println("[JSON] LENGTH ERROR");
    return;
  }

  HTTPClient http;
  WiFiClient client;

  String url = apiUrl("/data");
  http.begin(client, url);
  http.setTimeout(HTTP_TIMEOUT_MS);
  http.useHTTP10(true);
  http.setReuse(false);
  http.addHeader("Content-Type", "application/json");
  http.addHeader("X-API-Key", apiKey);

  int code = http.POST((uint8_t*)payload, len);

  Serial.print("[HTTP] data code=");
  Serial.println(code);

  if (code > 0) {
    int sz = http.getSize();
    if (sz > 0) {
      String resp = http.getString();
      Serial.print("[HTTP] data resp=");
      Serial.println(resp);
      if (resp.indexOf("inactive simulation") >= 0) {
        Serial.println("[SIM] inactive -> restart");
        simulationId = "";
        startSimulation();
      }
    }
  }
  http.end();
  client.stop();
  delay(20);
}

// ================= SENSORS =================
void initSensors() {
  sensorCount = 3;

  Serial.printf("%d capteurs configurés\n", sensorCount);

  for (int i = 0; i < sensorCount; i++) {
    sensorList[i].name = "Zone_" + String(i+1);
    sensorList[i].position = 50.0f * (i+1);  // adapte ici
    sensorList[i].temperature = NAN;
    sensorList[i].ok = false;
  }
}

void readSensors() {
  float T[3];

  float T1 = thermo1.readCelsius();
  float T2 = thermo2.readCelsius();
  float T3 = thermo3.readCelsius();

  T[0] = T1, T[1] = T2, T[2] = T3;

  for (int i = 0; i < sensorCount; i++) {
    float t = T[i];
    if (isnan(t) || t < -10.0f || t > 600.0f) {
      sensorList[i].temperature = NAN;
      sensorList[i].ok = false;
    } else {
      sensorList[i].temperature = t;
      sensorList[i].ok = true;
    }
  }
}

// ================== Setup ==================
void setup() {
  Serial.begin(9600);
  delay(500);  // Stabilisation MAX6675

  Serial.println("Mesure thermique par thermocouples type K");
  Serial.println("Format : T1(°C); T2(°C); T3(°C)");

  WiFi.mode(WIFI_STA);
  WiFi.begin(ssid, password);

  Serial.print("[WiFi] Connexion");
  unsigned long start = millis();
  while (WiFi.status() != WL_CONNECTED && millis() - start < 10000) {
    delay(300);
    Serial.print(".");
  }
  Serial.println();

  if (WiFi.status() == WL_CONNECTED) {
    Serial.print("[WiFi] OK IP: ");
    Serial.println(WiFi.localIP());
  } else {
    Serial.println("[WiFi] Échec, reconnexion auto plus tard.");
  }

  configTime(gmtOffset_sec, daylightOffset_sec, "pool.ntp.org", "time.nist.gov");

  initSensors();

  // Tente de démarrer une simulation au boot
  startSimulation();
  heap_caps_check_integrity_all(true);
}

// ================== Loop ==================
void loop() {
  unsigned long now = millis();

  if (now - lastReadTime >= READ_INTERVAL) {
    lastReadTime = now;

    readSensors();

    // Affichage série
    for (int i = 0; i < sensorCount; i++) {
      Serial.print(sensorList[i].name);
      Serial.print(" pos=");
      Serial.print(sensorList[i].position, 1);
      Serial.print(" temp=");
      if (!sensorList[i].ok) Serial.println("NA");
      else {
        Serial.print(sensorList[i].temperature, 2);
        Serial.println(" C");
      }
    }

    // Si pas de simulation active -> retente start
    if (simulationId.length() == 0) {
      startSimulation();
    }

    // Envoi data
    sendData();
  }
}
