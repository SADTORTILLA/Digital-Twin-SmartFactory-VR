using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StickerSocketInteractor : UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor
{
    [Header("Sticker Replacement")]
    public GameObject wrappedStickerPrefab;

    public Transform spawnPoint;

    [Tooltip("Small delay so step logic can detect the snap before replacement.")]
    [SerializeField] private float replaceDelaySeconds = 0.05f;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        // Make sure it's a grabbable sticker
        if (args.interactableObject is UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab)
        {
            StartCoroutine(ReplaceStickerAfterDelay(grab));
        }
    }

    private IEnumerator ReplaceStickerAfterDelay(UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable flatSticker)
    {
        if (replaceDelaySeconds > 0f)
            yield return new WaitForSeconds(replaceDelaySeconds);

        if (flatSticker == null || wrappedStickerPrefab == null)
            yield break;

        // Get final position (socket attach point)
        Transform socketAttachTransform = attachTransform; // XRSocketInteractor attach point
        if (socketAttachTransform == null)
            socketAttachTransform = transform;

        Vector3 pos = socketAttachTransform.position;
        Quaternion rot = socketAttachTransform.rotation;

        // Spawn wrapped sticker
        GameObject wrapped = Instantiate(wrappedStickerPrefab, pos, rot);
        if (wrapped == null)
            yield break;

        // Keep gameplay filtering coherent (tag/layer-based conditions)
        wrapped.tag = flatSticker.gameObject.tag;
        wrapped.layer = flatSticker.gameObject.layer;

        // Optional: match parent (important for bottle movement)
        wrapped.transform.SetParent(socketAttachTransform, worldPositionStays: true);

        // Remove flat sticker
        Destroy(flatSticker.gameObject);
    }
}