using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// Detects when the user attempts to grab (presses the select button) but fails to grab anything.
/// </summary>
public class FalseGrabDetector : MonoBehaviour
{
    [Tooltip("The input action used for grabbing (e.g., Grip Action).")]
    public InputActionReference grabAction;

    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor interactor;
    private StepManager stepManager;
    private bool isPressed = false;

    private void Awake()
    {
        interactor = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor>();
        if (interactor == null)
        {
            interactor = GetComponentInChildren<UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor>();
        }
    }

    private void Start()
    {
        stepManager = Object.FindAnyObjectByType<StepManager>();
        
        if (interactor == null) Debug.LogWarning($"[FalseGrabDetector] No XRBaseInteractor found on {gameObject.name} or its children!");
        if (stepManager == null) Debug.LogWarning($"[FalseGrabDetector] No StepManager found in the scene!");
        if (grabAction == null) Debug.LogWarning($"[FalseGrabDetector] Grab Action is not assigned on {gameObject.name}!");
    }

    private void OnEnable()
    {
        if (grabAction != null && grabAction.action != null)
        {
            grabAction.action.Enable(); // Ensure the action is enabled
            grabAction.action.performed += OnGrabPerformed;
            grabAction.action.canceled += OnGrabCanceled;
        }
    }

    private void OnDisable()
    {
        if (grabAction != null && grabAction.action != null)
        {
            grabAction.action.performed -= OnGrabPerformed;
            grabAction.action.canceled -= OnGrabCanceled;
        }
    }

    private void OnGrabPerformed(InputAction.CallbackContext context)
    {
        if (isPressed) return; // Prevent spam if it's an axis value (like Select Value)

        // If it's a float (like a trigger/grip), only count as pressed if value is past a threshold
        if (context.valueType == typeof(float))
        {
            if (context.ReadValue<float>() < 0.5f) return;
        }

        isPressed = true;

        if (interactor == null || stepManager == null) return;
        
        StartCoroutine(CheckForFalseGrab());
    }

    private void OnGrabCanceled(InputAction.CallbackContext context)
    {
        // Reset pressed state when the user lets go of the grip
        isPressed = false;
    }

    private IEnumerator CheckForFalseGrab()
    {
        // Wait until the end of the frame to give the interactor time to successfully grab something
        yield return new WaitForEndOfFrame();
        
        // If the interactor has no selection, it means they grabbed empty air
        if (interactor != null && !interactor.hasSelection)
        {
            stepManager.RecordFalseGrab();
        }
    }
}
