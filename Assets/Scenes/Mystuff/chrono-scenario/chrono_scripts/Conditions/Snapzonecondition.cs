using UnityEngine;

using System.Collections;

/// <summary>
/// Completes its step when an XRSocketInteractor has an object snapped into it.
///
/// Approach: poll socket.hasSelection every frame instead of using selectEntered.
/// This avoids all XRI event timing and lifecycle issues entirely.
///
/// The socket stays enabled at all times — we only start/stop polling.
/// On completion: freezes the Rigidbody and disables XRGrabInteractable
/// so the object stays locked in the socket permanently.
///
/// Scene setup:
///   - XRSocketInteractor can be on ANY GameObject — same or child, doesn't matter.
///   - Just assign it in the Inspector.
/// </summary>
public class SnapZoneCondition : StepCondition
{
    [Header("Snap Zone")]
    [Tooltip("The XRSocketInteractor the trainee must snap an object into.")]
    [SerializeField] private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;

    [Header("Optional Filter")]
    [Tooltip("Only an object with this tag completes the step. Leave empty to accept any.")]
    [SerializeField] private string requiredTag = "";

    [Header("Timing")]
    [Tooltip("Small delay after snap before completion to let pose/replacement settle.")]
    [SerializeField] private float settleDelaySeconds = 0.1f;

    private bool isPolling = false;
    private bool completionPending = false;

    // ─────────────────────────────────────────────
    //  StepCondition implementation
    // ─────────────────────────────────────────────
    public override void SetupCondition()
    {
        if (socket == null)
        {
            Debug.LogError($"[SnapZoneCondition] '{name}': No XRSocketInteractor assigned.");
            return;
        }

        isPolling = true;
        Debug.Log($"[SnapZoneCondition] '{name}': Now polling for snap.");
    }

    public override void TeardownCondition()
    {
        isPolling = false;
        completionPending = false;
    }

    // ─────────────────────────────────────────────
    //  Polling
    // ─────────────────────────────────────────────
    private void Update()
    {
        if (!isPolling || socket == null) return;

        if (!socket.hasSelection) return;

        // Something is snapped — check tag if required
        if (socket.firstInteractableSelected == null) return;
        GameObject snapped = socket.firstInteractableSelected.transform.gameObject;

        if (!string.IsNullOrEmpty(requiredTag) && !snapped.CompareTag(requiredTag))
        {
            Debug.Log($"[SnapZoneCondition] '{snapped.name}' snapped but wrong tag — ignoring.");
            return;
        }

        // Stop polling immediately so we don't schedule this twice.
        isPolling = false;
        completionPending = true;

        Debug.Log($"[SnapZoneCondition] '{name}': '{snapped.name}' snapped successfully.");
        StartCoroutine(CompleteAfterSettle(snapped));
    }

    // ─────────────────────────────────────────────
    //  Lock
    // ─────────────────────────────────────────────
    private void LockSnappedObject(GameObject snapped)
    {
        if (snapped == null) return;

        // Freeze physics so gravity can't pull it out
        Rigidbody rb = snapped.GetComponent<Rigidbody>();
        if (rb != null)
        {
            if (!rb.isKinematic)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            rb.isKinematic = true;
        }

        // Prevent the trainee from grabbing it again
        UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab = snapped.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (grab != null)
            grab.enabled = false;
    }

    private IEnumerator CompleteAfterSettle(GameObject snapped)
    {
        if (settleDelaySeconds > 0f)
            yield return new WaitForSeconds(settleDelaySeconds);
        else
            yield return null; // Always wait at least one frame.

        if (!completionPending)
            yield break;

        // The initially snapped object can be replaced by other scripts (e.g. sticker swap).
        // Fall back to current socket selection if the original instance no longer exists.
        GameObject target = snapped;
        if (target == null && socket != null && socket.firstInteractableSelected != null)
            target = socket.firstInteractableSelected.transform.gameObject;

        if (target != null)
            LockSnappedObject(target);

        completionPending = false;
        CompleteStep();
    }

    // ─────────────────────────────────────────────
    //  Validation
    // ─────────────────────────────────────────────
    private void OnValidate()
    {
        if (socket == null)
            socket = GetComponentInChildren<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>(includeInactive: true);
    }
}