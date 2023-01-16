using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.Windows;

public class Steer : MonoBehaviour
{
    private Interactable interactable;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }
    private void OnHandHoverBegin(Hand hand)
    {
        hand.ShowGrabHint();
    }
    private void OnHandHoverEnd(Hand hand)
    {
        hand.HideGrabHint();
    }
    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes grabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);

        //grab the object
        if (interactable.attachedToHand == null && grabType != GrabTypes.None)
        {
            hand.AttachObject(gameObject, grabType);
            hand.HoverLock(interactable);
            hand.HideGrabHint();
        }

        //release the object
        else if (isGrabEnding)
        {
            hand.DetachObject(gameObject);
            hand.HoverUnlock(interactable);
        }
    }
}
