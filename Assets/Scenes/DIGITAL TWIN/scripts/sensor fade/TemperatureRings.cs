using UnityEngine;

public class TemperatureRings : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] ExtrusionSoufflageData data;

    [Header("Ring Transforms — place inside machine")]
    [SerializeField] Transform zone1Ring;
    [SerializeField] Transform zone2Ring;
    [SerializeField] Transform zone3Ring;

    [Header("Ring Renderers")]
    [SerializeField] Renderer zone1Renderer;
    [SerializeField] Renderer zone2Renderer;
    [SerializeField] Renderer zone3Renderer;

    [Header("Thresholds")]
    [SerializeField] float warningTemp  = 80f;
    [SerializeField] float criticalTemp = 100f;

    [Header("Animation")]
    [SerializeField] float minPulseSpeed = 0.5f;
    [SerializeField] float maxPulseSpeed = 3.0f;
    [SerializeField] float minScale      = 0.8f;
    [SerializeField] float maxScale      = 1.2f;

    MaterialPropertyBlock mpb;

    void Awake() => mpb = new MaterialPropertyBlock();

    void Update()
    {
        UpdateRing(zone1Ring, zone1Renderer, data.tempZone1);
        UpdateRing(zone2Ring, zone2Renderer, data.tempZone2);
        UpdateRing(zone3Ring, zone3Renderer, data.tempZone3);
    }

    void UpdateRing(Transform ring, Renderer rend, float temp)
    {
        if (ring == null || rend == null) return;

        // pulse speed based on temperature
        float t          = Mathf.InverseLerp(60f, 120f, temp);
        float pulseSpeed = Mathf.Lerp(minPulseSpeed, maxPulseSpeed, t);
        float pulse      = Mathf.Sin(Time.time * pulseSpeed) * 0.5f + 0.5f;

        // scale ring with pulse
        float scale = Mathf.Lerp(minScale, maxScale, pulse);
        ring.localScale = Vector3.one * scale;

        // color based on temperature
        Color color = GetTempColor(temp);
        rend.GetPropertyBlock(mpb);
        mpb.SetColor("_Color",        color);
        mpb.SetColor("_EmissionColor", color * 1.5f); // glow
        rend.SetPropertyBlock(mpb);
    }

    // called by GazeReveal to fade in/out
    public void SetAlpha(float alpha)
    {
        SetRendererAlpha(zone1Renderer, alpha);
        SetRendererAlpha(zone2Renderer, alpha);
        SetRendererAlpha(zone3Renderer, alpha);
    }

    void SetRendererAlpha(Renderer rend, float alpha)
    {
        if (rend == null) return;
        rend.GetPropertyBlock(mpb);
        Color c = mpb.GetColor("_Color");
        c.a = alpha;
        mpb.SetColor("_Color", c);
        rend.SetPropertyBlock(mpb);
    }

    Color GetTempColor(float temp)
    {
        if (temp >= criticalTemp) return new Color(1f, 0.2f, 0.1f); // red
        if (temp >= warningTemp)  return new Color(1f, 0.75f, 0f);  // yellow
        return new Color(0.1f, 0.8f, 1f);                           // cyan
    }
}