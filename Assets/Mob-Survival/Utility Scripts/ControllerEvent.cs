using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControllerEvent : MonoBehaviour
{
    public UnityEvent triggerPressEvent;

    private OVRInput.Controller controller;
    private OVRInput.Button triggerButton;

    private void Start()
    {
        // Set the appropriate controller and button for the Oculus Quest II trigger
        controller = OVRInput.Controller.RTouch;
        triggerButton = OVRInput.Button.PrimaryIndexTrigger;
    }

    private void Update()
    {
        // Check if the trigger button is pressed on the Oculus Quest II controller
        if (OVRInput.GetDown(triggerButton, controller))
        {
            // Trigger the UnityEvent
            triggerPressEvent.Invoke();
        }
    }
}
