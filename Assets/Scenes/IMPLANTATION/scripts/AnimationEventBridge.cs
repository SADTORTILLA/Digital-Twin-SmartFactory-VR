using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventBridge : MonoBehaviour
{
    [Header("References")]
    public Animator animator;
    public string animationTriggerName = "PlayCut";

    [Header("Events")]
    public UnityEvent OnAnimationStart;
    public UnityEvent OnAnimationComplete;

    private bool isPlaying;

    public void PlayAnimation()
    {
        if (isPlaying || animator == null)
            return;

        StartCoroutine(PlayRoutine());
    }

    private IEnumerator PlayRoutine()
    {
        isPlaying = true;

        OnAnimationStart?.Invoke();

        animator.SetTrigger(animationTriggerName);

        // Wait one frame so Animator updates state
        yield return null;

        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);

        // Wait until animation finishes
        yield return new WaitForSeconds(state.length);

        isPlaying = false;

        OnAnimationComplete?.Invoke();
    }
}