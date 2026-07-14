using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

[RequireComponent(typeof(XRSocketInteractor))]
public class SocketCondition : MonoBehaviour
{
    [SerializeField] private string requiredTag;

    public event Action OnValidObjectSnapped;

    private XRSocketInteractor socket;

    private void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    private void OnEnable()
    {
        socket.selectEntered.AddListener(HandleSnap);
    }

    private void OnDisable()
    {
        socket.selectEntered.RemoveListener(HandleSnap);
    }

    private void HandleSnap(SelectEnterEventArgs args)
    {
        GameObject obj = args.interactableObject.transform.gameObject;

        if (!string.IsNullOrEmpty(requiredTag) &&
            !obj.CompareTag(requiredTag))
            return;

        OnValidObjectSnapped?.Invoke();
    }
}