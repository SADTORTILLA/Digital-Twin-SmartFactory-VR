using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class XRGrabInteractableTwoAttached : UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable
{

    public Transform leftAttachedTransform ;
    public Transform rightAttachedTransform ;

    public override Transform GetAttachTransform(UnityEngine.XR.Interaction.Toolkit.Interactors.IXRInteractor interactor){
        //Debug.Log("GetAttachTransform");

        Transform i_attachTransform = null ;

        if(interactor.transform.CompareTag("LeftHand")){
            //Debug.Log("Left") ;
            i_attachTransform  = leftAttachedTransform ;
        }
        if(interactor.transform.CompareTag("RightHand")){
            //Debug.Log("Right") ;
            i_attachTransform  = rightAttachedTransform ;
        }
        return i_attachTransform != null ? i_attachTransform : base.GetAttachTransform(interactor);
    }
}