using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabHandPose : MonoBehaviour
{
    public HandData RightHandPose;
    private Vector3 startinghandposition;
    private Vector3 finalhandposition;
    private Quaternion startinghandrotation;
    private Quaternion finalhandrotation;
    private Quaternion[] startingfingerrotation;
    private Quaternion[] finalfingerrotation;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        
        grabInteractable.selectEntered.AddListener(SetUpPose);
        grabInteractable.selectExited.AddListener(UnSetPose);

        RightHandPose.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void SetUpPose(BaseInteractionEventArgs args)
    {
        if (args.interactorObject is UnityEngine.XR.Interaction.Toolkit.Interactors.XRDirectInteractor)
        {
            HandData handData = args.interactorObject.transform.parent.GetComponentInChildren<HandData>();
            handData.animator.enabled = false;

            SetHandDataValues(handData,RightHandPose);
            SetHandData(handData, startinghandposition, startinghandrotation, finalfingerrotation);

        }

    }
    public void SetHandDataValues(HandData h1,HandData h2)
    {
        startinghandposition = h1.root.localPosition;
        finalhandposition = h2.root.localPosition;

        startinghandrotation = h1.root.localRotation;
        finalhandrotation = h2.root.localRotation;

        startingfingerrotation = new Quaternion[h1.fingerBones.Length];
        finalfingerrotation = new Quaternion[h1.fingerBones.Length];

        for(int i = 0 ; i < h1.fingerBones.Length ; i++)
        {
            startingfingerrotation[i] = h1.fingerBones[i].localRotation;
            finalfingerrotation[i] = h2.fingerBones[i].localRotation;
        }
    }
    public void SetHandData(HandData h, Vector3 newPosition, Quaternion newRotation, Quaternion[] newBonesRotation)
    {
        h.root.localPosition = newPosition;
        h.root.localRotation = newRotation;
        for (int i = 0; i < newBonesRotation.Length; i++)
        {
            h.fingerBones[i].localRotation = newBonesRotation[i];
        }
    }
    public void UnSetPose(BaseInteractionEventArgs args)
    {
        if (args.interactorObject is UnityEngine.XR.Interaction.Toolkit.Interactors.XRDirectInteractor)
        {
            HandData handData = args.interactorObject.transform.parent.GetComponentInChildren<HandData>();
            
            if (handData == null) return;
            
            SetHandData(handData, startinghandposition, startinghandrotation, startingfingerrotation);
            handData.animator.enabled = true;
        }
    }
}