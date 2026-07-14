using System;
using UnityEngine;

public class MachineAnimator : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator animator;

    [Header("Parameters")]
    [SerializeField] private string cutTrigger = "Cut";

    public event Action OnAnimationStarted;
    public event Action OnAnimationFinished;

    private bool isPlaying;

    public bool IsPlaying => isPlaying;

    public void PlayCutAnimation()
    {
        if (isPlaying || animator == null)
            return;

        isPlaying = true;

        animator.SetTrigger(cutTrigger);

        OnAnimationStarted?.Invoke();
    }

    // Called from Animation Event
    public void AnimationFinished()
    {
        isPlaying = false;

        OnAnimationFinished?.Invoke();
    }
}