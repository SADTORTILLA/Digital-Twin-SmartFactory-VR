using UnityEngine;

// ─────────────────────────────────────────────────────────────────────────────
// ZoneIndicator.cs
// A flat glowing circle on the ground that pulses to show a placement zone.
//
// SETUP:
//   1. Create a Cylinder in Unity (scale Y very flat, e.g. 0.01)
//      OR use a Quad rotated flat on the ground
//   2. Attach this script to it
//   3. Assign a material with Emission enabled (Standard, Transparent)
//   4. Drag this GameObject into the step's Indicators list in StepManager
// ─────────────────────────────────────────────────────────────────────────────

public class ZoneIndicator : StepIndicator
{
    [Header("Zone Settings")]
    [Tooltip("Speed of the pulse animation")]
    public float pulseSpeed = 1.2f;

    [Tooltip("Min and max alpha during pulsing")]
    public float pulseMin = 0.3f;
    public float pulseMax = 0.8f;

    private bool isShowing = false;

    // ── Unity ─────────────────────────────────────────────────────────────────

    private void Update()
    {
        if (!isShowing) return;

        // Pulse the alpha between min and max
        float alpha = Mathf.Lerp(pulseMin, pulseMax,
            (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f);

        SetAlpha(alpha);
    }

    // ── Overrides ─────────────────────────────────────────────────────────────

    protected override void OnShow()
    {
        isShowing = true;
    }

    protected override void OnHide()
    {
        isShowing = false;
    }
}