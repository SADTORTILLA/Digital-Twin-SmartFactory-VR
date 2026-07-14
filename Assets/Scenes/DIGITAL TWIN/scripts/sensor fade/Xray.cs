using UnityEngine;

public class XRayEffect : MonoBehaviour
{
    [Header("Gaze")]
    [SerializeField] float gazeDistance = 8f;
    [SerializeField] float fadeSpeed = 3f;

    [Header("Machine Shells")]
    [SerializeField] GameObject[] opaqueShells;
    [SerializeField] GameObject[] transparentShells;

    [Header("Ring Canvases")]
    [SerializeField] CanvasGroup[] zoneCanvases;

    Camera headset;
    float alpha = 0f;

    void Start()
    {
        headset = Camera.main;

        // Start state
        SetObjectsActive(opaqueShells, true);
        SetObjectsActive(transparentShells, false);

        foreach (var cg in zoneCanvases)
            cg.alpha = 0f;
    }

    void Update()
    {
        bool isLooking = IsPlayerLooking();

        alpha = Mathf.MoveTowards(
            alpha,
            isLooking ? 1f : 0f,
            fadeSpeed * Time.deltaTime
        );

        // Swap shells
        SetObjectsActive(opaqueShells, alpha < 0.5f);
        SetObjectsActive(transparentShells, alpha >= 0.5f);

        // Fade canvases
        foreach (var cg in zoneCanvases)
            cg.alpha = alpha;
    }

    void SetObjectsActive(GameObject[] objects, bool state)
    {
        foreach (GameObject obj in objects)
        {
            if (obj != null)
                obj.SetActive(state);
        }
    }

    bool IsPlayerLooking()
    {
        Ray ray = new Ray(
            headset.transform.position,
            headset.transform.forward
        );

        if (Physics.Raycast(ray, out RaycastHit hit, gazeDistance))
        {
            return hit.collider.gameObject == gameObject
                || hit.collider.transform.IsChildOf(transform);
        }

        return false;
    }
}