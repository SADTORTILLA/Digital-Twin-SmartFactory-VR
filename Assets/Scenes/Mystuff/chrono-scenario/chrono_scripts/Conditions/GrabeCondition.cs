using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Completes its step when the assigned XRGrabInteractable is grabbed.
///
/// For the FIRST step (isFirstStep = true):
///   Calls StartScenario() which starts the global timer, then advances.
///
/// For all other grab steps:
///   Calls CompleteStep() to simply advance to the next step.
///
/// Setup:   Subscribes to the selectEntered event.
/// Teardown: Unsubscribes from the selectEntered event.
/// </summary>
public class GrabCondition : StepCondition
{
    [Header("Grab Target")]
    [Tooltip("The XRGrabInteractable the trainee must grab to complete this step.")]
    [SerializeField] private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    [Header("Step Role")]
    [Tooltip("Enable for Step 1 only. Calls StartScenario() instead of CompleteStep() to kick off the timer.")]
    [SerializeField] public bool isFirstStep = false;

    // ─────────────────────────────────────────────
    //  StepCondition implementation
    // ─────────────────────────────────────────────
    public override void SetupCondition()
    {
        if (grabInteractable == null)
        {
            Debug.LogError($"[GrabCondition] '{name}': No XRGrabInteractable assigned.");
            return;
        }

        grabInteractable.selectEntered.AddListener(OnGrabbed);
        Debug.Log($"[GrabCondition] Waiting for grab on '{grabInteractable.name}'.");
    }

    public override void TeardownCondition()
    {
        if (grabInteractable != null)
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
    }

    // ─────────────────────────────────────────────
    //  Event handler
    // ─────────────────────────────────────────────
    private void OnGrabbed(SelectEnterEventArgs args)
    {
        // Immediately unsubscribe so we don't fire twice
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);

        Debug.Log($"[GrabCondition] '{grabInteractable.name}' was grabbed.");

        if (isFirstStep)
            StartScenario();   // starts the timer + advances
        else
            CompleteStep();    // just advances
    }

    // ─────────────────────────────────────────────
    //  Validation helper
    // ─────────────────────────────────────────────
    private void OnValidate()
    {
        if (grabInteractable == null)
            grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
    }
}