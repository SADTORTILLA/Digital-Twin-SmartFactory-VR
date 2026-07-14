using UnityEngine;

/// <summary>
/// Abstract base class for all step conditions.
/// Inherit from this and implement SetupCondition() and TeardownCondition().
/// Call CompleteStep() when the condition is satisfied.
/// Call StartScenario() for the first step (starts the timer).
/// </summary>
public abstract class StepCondition : MonoBehaviour
{
    protected StepManager stepManager;

    /// <summary>
    /// Called by StepManager when this step becomes active.
    /// Override to subscribe to events, enable colliders, etc.
    /// </summary>
    public abstract void SetupCondition();

    /// <summary>
    /// Called by StepManager when this step ends (success or skip).
    /// Override to unsubscribe from events, disable colliders, etc.
    /// </summary>
    public abstract void TeardownCondition();

    /// <summary>
    /// Inject the StepManager reference. Called automatically by StepManager.
    /// </summary>
    public void Initialize(StepManager manager)
    {
        stepManager = manager;
    }

    /// <summary>
    /// Called by StepManager to activate this condition.
    /// </summary>
    public void Activate()
    {
        SetupCondition();
    }

    /// <summary>
    /// Called by StepManager to deactivate this condition.
    /// </summary>
    public void Deactivate()
    {
        TeardownCondition();
    }

    /// <summary>
    /// Call this from a subclass when the step's condition has been met.
    /// </summary>
    protected void CompleteStep()
    {
        if (stepManager != null)
            stepManager.CompleteCurrentStep();
        else
            Debug.LogWarning($"[StepCondition] {name}: StepManager reference is null. Did you call Initialize()?");
    }

    /// <summary>
    /// Call this from the FIRST step's condition instead of CompleteStep().
    /// Starts the global scenario timer before advancing.
    /// </summary>
    protected void StartScenario()
    {
        if (stepManager != null)
            stepManager.StartScenario();
        else
            Debug.LogWarning($"[StepCondition] {name}: StepManager reference is null. Did you call Initialize()?");
    }
}