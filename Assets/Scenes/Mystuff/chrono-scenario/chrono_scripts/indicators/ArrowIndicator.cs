using UnityEngine;

// ─────────────────────────────────────────────────────────────────────────────
// ArrowIndicator.cs
// A 3D arrow that hovers and bobs above a target object.
//
// SETUP:
//   1. Create a GameObject with your 3D arrow model as a child
//   2. Attach this script to the root GameObject
//   3. Set "target" to the object you want the arrow to point at
//   4. Drag this GameObject into the step's Indicators list in StepManager
// ─────────────────────────────────────────────────────────────────────────────

public class ArrowIndicator : StepIndicator
{
    [Header("Arrow Settings")]
    [Tooltip("The object the arrow will hover above")]
    public Transform target;

    [Tooltip("How high above the target the arrow floats")]
    public float hoverHeight = 0.3f;

    [Tooltip("How much the arrow bobs up and down")]
    public float bobAmount = 0.05f;

    [Tooltip("Speed of the bobbing animation")]
    public float bobSpeed = 2f;

    private bool isShowing = false;

    // ── Unity ─────────────────────────────────────────────────────────────────

    private void Update()
    {
        if (!isShowing || target == null) return;

        // Follow target position + hover height + bob
        float bob = Mathf.Sin(Time.time * bobSpeed) * bobAmount;
        transform.position = target.position + Vector3.up * (hoverHeight + bob);

        // Always point downward (arrow tip facing the target)
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
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