using UnityEngine;

/// <summary>
/// Completes its step when a GameObject with the specified tag
/// enters this GameObject's trigger collider.
///
/// Usage:
///   • Add this component to a trigger-collider zone (an empty GameObject
///     with a Collider set to "Is Trigger").
///   • Set requiredTag to match the tag on the object that must be placed
///     (e.g., "BacVide", "Etiquette", "FlaconEtiquete").
///   • For snap-zone steps (step 6), the snap zone itself fires the trigger.
///
/// Setup:   Enables the trigger collider so placements register.
/// Teardown: Disables the trigger collider to ignore further entries.
/// </summary>
public class PlacementCondition : StepCondition
{
    [Header("Placement Settings")]
    [Tooltip("Tag of the GameObject that must enter this trigger zone to complete the step.")]
    [SerializeField] private string requiredTag = "";

    [Tooltip("The trigger collider used as the placement zone. Auto-detected if left empty.")]
    [SerializeField] private Collider zoneCollider;

    // ─────────────────────────────────────────────
    //  StepCondition implementation
    // ─────────────────────────────────────────────
    public override void SetupCondition()
    {
        if (zoneCollider == null)
        {
            Debug.LogError($"[PlacementCondition] '{name}': No Collider found. Attach one and mark it as Trigger.");
            return;
        }

        zoneCollider.enabled = true;
        Debug.Log($"[PlacementCondition] '{name}': Waiting for object tagged '{requiredTag}' to enter zone.");
    }

    public override void TeardownCondition()
    {
        if (zoneCollider != null)
            zoneCollider.enabled = false;
    }

    // ─────────────────────────────────────────────
    //  Trigger detection
    // ─────────────────────────────────────────────
    private void OnTriggerEnter(Collider other)
    {
        // Only react when this step is active (collider is enabled)
        if (!zoneCollider.enabled) return;

        if (!string.IsNullOrEmpty(requiredTag) && !other.CompareTag(requiredTag))
            return;

        Debug.Log($"[PlacementCondition] '{name}': '{other.name}' placed correctly.");

        // Disable immediately to prevent duplicate triggers
        zoneCollider.enabled = false;

        CompleteStep();
    }

    // ─────────────────────────────────────────────
    //  Validation helper
    // ─────────────────────────────────────────────
    private void OnValidate()
    {
        if (zoneCollider == null)
            zoneCollider = GetComponent<Collider>();

        if (zoneCollider != null && !zoneCollider.isTrigger)
            Debug.LogWarning($"[PlacementCondition] '{name}': Collider is not set to 'Is Trigger'. Please enable it.");
    }

    private void Awake()
    {
        if (zoneCollider == null)
            zoneCollider = GetComponent<Collider>();

        // Start disabled — SetupCondition() will enable it when the step is active
        if (zoneCollider != null)
            zoneCollider.enabled = false;
    }
}