using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ExtrusionSoufflageReceiver : MonoBehaviour
{
    [SerializeField] string serverIP = "172.16.1.14";
    [SerializeField] float  pollRate = 0.5f;
    [SerializeField] ExtrusionSoufflageData data;

    void Start() => StartCoroutine(PollServer());

    IEnumerator PollServer()
    {
        while (true)
        {
            string url = $"http://{serverIP}:8000/extrusion-soufflage/latest";

            using var req = UnityWebRequest.Get(url);
            yield return req.SendWebRequest();

            if (req.result == UnityWebRequest.Result.Success)
            {
                var payload = JsonUtility.FromJson<ExtrusionPayload>(req.downloadHandler.text);
                data.tempZone1    = payload.temp_zone_1;
                data.tempZone2    = payload.temp_zone_2;
                data.tempZone3    = payload.temp_zone_3;
                data.lastUpdated  = payload.timestamp;
            }
            else
            {
                Debug.LogWarning("Server unreachable: " + req.error);
            }

            yield return new WaitForSeconds(pollRate);
        }
    }

    [System.Serializable]
    class ExtrusionPayload
    {
        public float  temp_zone_1;
        public float  temp_zone_2;
        public float  temp_zone_3;
        public string timestamp;
    }
}