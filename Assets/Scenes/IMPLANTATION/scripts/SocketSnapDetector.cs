using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

[RequireComponent(typeof(XRSocketInteractor))]
public class SocketSnapDetector : MonoBehaviour
{
    [Header("Validation")]
    public string requiredTag = "";

    [Header("Events")]
    public UnityEvent OnObjectSnapped;
    public UnityEvent OnObjectRemoved;

    private XRSocketInteractor socketInteractor;

    private void Awake()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
    }

    private void OnEnable()
    {
        socketInteractor.selectEntered.AddListener(HandleSnap);
        socketInteractor.selectExited.AddListener(HandleRemove);
    }

    private void OnDisable()
    {
        socketInteractor.selectEntered.RemoveListener(HandleSnap);
        socketInteractor.selectExited.RemoveListener(HandleRemove);
    }

    private void HandleSnap(SelectEnterEventArgs args)
    {
        GameObject snappedObject = args.interactableObject.transform.gameObject;

        if (!string.IsNullOrEmpty(requiredTag) &&
            !snappedObject.CompareTag(requiredTag))
        {
            return;
        }

        OnObjectSnapped?.Invoke();
    }

    private void HandleRemove(SelectExitEventArgs args)
    {
        OnObjectRemoved?.Invoke();
    }
}