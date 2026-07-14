using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ZoneRingCard : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] ExtrusionSoufflageData data;
    [SerializeField] int zoneIndex = 1; // 1, 2 or 3

    [Header("UI References")]
    [SerializeField] Image    ringFill;
    [SerializeField] Image    ringBackground;
    [SerializeField] TMP_Text tempValueText;
    [SerializeField] TMP_Text zoneLabelText;
    [SerializeField] TMP_Text statusText;

    [Header("Thresholds")]
    [SerializeField] float minTemp      = 60f;
    [SerializeField] float maxTemp      = 120f;
    [SerializeField] float warningTemp  = 80f;
    [SerializeField] float criticalTemp = 100f;

    [Header("Pulse")]
    [SerializeField] float minPulseSpeed = 0.5f;
    [SerializeField] float maxPulseSpeed = 3.0f;

    readonly Color colorNormal   = new Color(0.1f, 0.8f,  1f,  1f);
    readonly Color colorWarning  = new Color(1f,   0.75f, 0f,  1f);
    readonly Color colorCritical = new Color(1f,   0.2f,  0.1f,1f);
    readonly Color trackColor    = new Color(0.1f, 0.1f,  0.1f,0.8f);

    void Start()
    {
        zoneLabelText.text   = $"ZONE {zoneIndex}";
        ringBackground.color = trackColor;

        // setup ring fill
        ringFill.type       = Image.Type.Filled;
        ringFill.fillMethod = Image.FillMethod.Radial360;
        ringFill.fillOrigin = (int)Image.Origin360.Top;
        ringFill.fillClockwise = true;
    }

    void Update()
    {
        if (data == null) return;

        float temp  = GetZoneTemp();
        Color color = GetColor(temp);

        // fill ring
        ringFill.fillAmount = Mathf.InverseLerp(minTemp, maxTemp, temp);

        // pulse the color on critical
        if (temp >= criticalTemp)
        {
            float t     = Mathf.InverseLerp(60f, 120f, temp);
            float speed = Mathf.Lerp(minPulseSpeed, maxPulseSpeed, t);
            float pulse = Mathf.Abs(Mathf.Sin(Time.time * speed));
            color.a     = Mathf.Lerp(0.5f, 1f, pulse);
        }

        ringFill.color     = color;
        tempValueText.text  = $"{temp:F1}°C";
        tempValueText.color = color;
        statusText.text     = GetStatus(temp);
        statusText.color    = color;
    }

    float GetZoneTemp() => zoneIndex switch
    {
        1 => data.tempZone1,
        2 => data.tempZone2,
        3 => data.tempZone3,
        _ => 0f
    };

    Color GetColor(float temp)
    {
        if (temp >= criticalTemp) return colorCritical;
        if (temp >= warningTemp)  return colorWarning;
        return colorNormal;
    }

    string GetStatus(float temp)
    {
        if (temp >= criticalTemp) return "CRITICAL";
        if (temp >= warningTemp)  return "WARNING";
        return "NORMAL";
    }
}