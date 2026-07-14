using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class CuttingMachineController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private XRSocketInteractor socketInteractor;

    [SerializeField] private MachineAnimator machineAnimator;

    [SerializeField] private AudioSource cuttingAudio;

    private CuttableObject currentObject;

    private void OnEnable()
    {
        socketInteractor.selectEntered.AddListener(OnObjectInserted);

        machineAnimator.OnAnimationStarted += HandleAnimationStarted;
        machineAnimator.OnAnimationFinished += HandleCutFinished;
    }

    private void OnDisable()
    {
        socketInteractor.selectEntered.RemoveListener(OnObjectInserted);

        machineAnimator.OnAnimationStarted -= HandleAnimationStarted;
        machineAnimator.OnAnimationFinished -= HandleCutFinished;
    }

    private void OnObjectInserted(SelectEnterEventArgs args)
    {
        if (machineAnimator.IsPlaying)
            return;

        GameObject insertedObject =
            args.interactableObject.transform.gameObject;

        CuttableObject cuttable =
            insertedObject.GetComponent<CuttableObject>();

        if (cuttable == null)
            return;

        currentObject = cuttable;

        machineAnimator.PlayCutAnimation();
    }

    private void HandleAnimationStarted()
    {
        if (cuttingAudio != null)
        {
            cuttingAudio.Play();
        }
    }

    private void HandleCutFinished()
    {
        if (cuttingAudio != null)
        {
            cuttingAudio.Stop();
        }

        if (currentObject == null)
            return;

        currentObject.Process();

        currentObject = null;

        ResetMachine();
    }

    private void ResetMachine()
    {
        Debug.Log("Machine Reset");
    }
}