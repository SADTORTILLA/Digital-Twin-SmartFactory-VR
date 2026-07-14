using System.Collections;
using UnityEngine;

// ─────────────────────────────────────────────────────────────────────────────
// StepIndicator.cs
// Base class for all visual indicators (arrow, outline, zone marker).
// Do NOT attach this directly — use ArrowIndicator, OutlineIndicator, or
// ZoneIndicator instead.
//
// Handles fade in/out smoothly. Each child class overrides:
//   OnShow() — called when fully visible
//   OnHide() — called when fully hidden
// ─────────────────────────────────────────────────────────────────────────────

public abstract class StepIndicator : MonoBehaviour
{
    [Header("Fade Settings")]
    public float fadeDuration = 0.4f;

    // Every indicator needs a renderer to fade
    protected Renderer[] renderers;
    private Coroutine fadeCoroutine;

    // ── Unity ─────────────────────────────────────────────────────────────────

    protected virtual void Awake()
    {
        renderers = GetComponentsInChildren<Renderer>();

        // Start fully hidden
        SetAlpha(0f);
        gameObject.SetActive(false);
    }

    // ── Public API ────────────────────────────────────────────────────────────

    public void Show()
    {
        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        gameObject.SetActive(true);
        fadeCoroutine = StartCoroutine(Fade(0f, 1f, onDone: OnShow));
    }

    public void Hide()
    {
        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        fadeCoroutine = StartCoroutine(Fade(1f, 0f, onDone: () =>
        {
            OnHide();
            gameObject.SetActive(false);
        }));
    }

    // ── Overrideable ──────────────────────────────────────────────────────────

    /// <summary>Called when the indicator has fully faded in.</summary>
    protected virtual void OnShow() { }

    /// <summary>Called when the indicator has fully faded out.</summary>
    protected virtual void OnHide() { }

    // ── Fade Logic ────────────────────────────────────────────────────────────

    private IEnumerator Fade(float from, float to, System.Action onDone = null)
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(from, to, t / fadeDuration);
            SetAlpha(alpha);
            yield return null;
        }
        SetAlpha(to);
        onDone?.Invoke();
    }

    protected void SetAlpha(float alpha)
    {
        foreach (Renderer r in renderers)
        {
            foreach (Material mat in r.materials)
            {
                // Works with Standard shader (Fade or Transparent mode)
                Color c = mat.color;
                c.a = alpha;
                mat.color = c;
            }
        }
    }
}