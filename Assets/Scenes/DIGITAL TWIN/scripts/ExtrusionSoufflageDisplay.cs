using UnityEngine;
using TMPro;

public class ExtrusionSoufflageDisplay : MonoBehaviour
{
    [SerializeField] ExtrusionSoufflageData data;

    [Header("UI")]
    [SerializeField] TMP_Text titleText;
    [SerializeField] TMP_Text zone1Text;
    [SerializeField] TMP_Text zone2Text;
    [SerializeField] TMP_Text zone3Text;
    [SerializeField] TMP_Text timestampText;

    [Header("Thresholds")]
    [SerializeField] float warningTemp = 80f;
    [SerializeField] float criticalTemp = 100f;

    [Header("Colors")]
    [SerializeField] Color normalColor   = Color.white;
    [SerializeField] Color warningColor  = Color.yellow;
    [SerializeField] Color criticalColor = Color.red;

    void Update()
    {
        if (data == null) return;

        titleText.text     = "Extrusion Soufflage";
        zone1Text.text     = $"Zone 1: {data.tempZone1:F1} °C";
        zone2Text.text     = $"Zone 2: {data.tempZone2:F1} °C";
        zone3Text.text     = $"Zone 3: {data.tempZone3:F1} °C";
        timestampText.text = $"Updated: {data.lastUpdated}";

        zone1Text.color = GetTempColor(data.tempZone1);
        zone2Text.color = GetTempColor(data.tempZone2);
        zone3Text.color = GetTempColor(data.tempZone3);
    }

    Color GetTempColor(float temp)
    {
        if (temp >= criticalTemp) return criticalColor;
        if (temp >= warningTemp)  return warningColor;
        return normalColor;
    }
}