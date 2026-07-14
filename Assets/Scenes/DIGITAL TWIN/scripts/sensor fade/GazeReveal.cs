using UnityEngine;

public class GazeReveal : MonoBehaviour
{
    [Header("Gaze")]
    [SerializeField] float fadeSpeed    = 3f;
    [SerializeField] float gazeDistance = 8f;

    [Header("Target Canvas Groups — one per zone card")]
    [SerializeField] CanvasGroup[] zoneCanvases;

    Camera headset;

    void Start()
    {
        headset = Camera.main;

        // start all invisible
        foreach (var cg in zoneCanvases)
        {
            cg.alpha          = 0f;
            cg.interactable   = false;
            cg.blocksRaycasts = false;
        }
    }

    void Update()
    {
        bool isLooking = IsPlayerLooking();

        foreach (var cg in zoneCanvases)
        {
            cg.alpha = Mathf.MoveTowards(
                cg.alpha,
                isLooking ? 1f : 0f,
                fadeSpeed * Time.deltaTime
            );
        }
    }

    bool IsPlayerLooking()
    {
        Ray ray = new Ray(headset.transform.position,
                          headset.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, gazeDistance))
            return hit.collider.gameObject == gameObject
                || hit.collider.transform.IsChildOf(transform);

        return false;
    }
}