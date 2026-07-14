using System.Collections.Generic;
using UnityEngine;

// ─────────────────────────────────────────────────────────────────────────────
// StepSpawner.cs
// Attach to any GameObject in the scene.
// Watches StepManager every frame and spawns objects when the target step
// starts. No changes needed to StepManager.
//
// SETUP:
//   1. Attach this script to any GameObject (e.g. "Spawner_Bottles")
//   2. Assign the StepManager reference
//   3. Set "stepIndex" to the step number you want (0 = Step 1, 1 = Step 2...)
//   4. Set "hideStepIndex" if you want the objects to disappear later (-1 to never hide)
//   5. Add all objects to spawn into "objectsToSpawn"
//   6. Make sure those objects are DISABLED in the scene to start
// ─────────────────────────────────────────────────────────────────────────────

public class StepSpawner : MonoBehaviour
{
    [Header("References")]
    public StepManager stepManager;

    [Tooltip("Which step triggers the spawn (0 = Step 1, 1 = Step 2, etc.)")]
    public int stepIndex;

    [Tooltip("Which step triggers the hide/deactivation. Set to -1 to never hide.")]
    public int hideStepIndex = -1;

    [Tooltip("Objects to enable when the spawn step starts, and hide when the hide step starts")]
    public List<GameObject> objectsToSpawn = new List<GameObject>();

    private bool hasSpawned = false;
    private bool hasHidden = false;
    private int lastCheckedStep = -1;

    private void Start()
    {
        // Make sure all objects start hidden
        foreach (var obj in objectsToSpawn)
            if (obj != null) obj.SetActive(false);
    }

    private void Update()
    {
        if (stepManager == null) return;
        
        // Stop checking if both actions are done (or if hiding is disabled and spawning is done)
        if (hasSpawned && (hasHidden || hideStepIndex == -1)) return;

        int current = stepManager.CurrentStep;

        // Only fire once when the step index is reached
        if (current != lastCheckedStep)
        {
            lastCheckedStep = current;

            if (!hasSpawned && current == stepIndex)
            {
                Spawn();
            }
            
            if (hasSpawned && !hasHidden && hideStepIndex != -1 && current == hideStepIndex)
            {
                Hide();
            }
        }
    }

    // Optional event-style trigger from StepManager.
    // Kept alongside polling so either integration style works.
    public void OnStepStarted(string stepText)
    {
        if (stepManager == null) return;

        int current = stepManager.CurrentStep;
        
        if (!hasSpawned && current == stepIndex)
            Spawn();
            
        if (hasSpawned && !hasHidden && hideStepIndex != -1 && current == hideStepIndex)
            Hide();
    }

    private void Spawn()
    {
        hasSpawned = true;
        foreach (var obj in objectsToSpawn)
        {
            if (obj != null)
            {
                obj.SetActive(true);
                Debug.Log($"[StepSpawner] Spawned '{obj.name}' at step {stepIndex + 1}");
            }
        }
    }

    private void Hide()
    {
        hasHidden = true;
        foreach (var obj in objectsToSpawn)
        {
            if (obj != null)
            {
                obj.SetActive(false);
                Debug.Log($"[StepSpawner] Hid '{obj.name}' at step {hideStepIndex + 1}");
            }
        }
    }
}