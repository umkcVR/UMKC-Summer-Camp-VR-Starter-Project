using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCRUPT : MonoBehaviour
{
    public Camera targetCamera;  // Reference to the target camera

    void LateUpdate()
    {
        // Calculate the desired rotation to face the camera
        Quaternion targetRotation = Quaternion.LookRotation(transform.position - targetCamera.transform.position);

        // Apply the rotation to the canvas
        transform.rotation = targetRotation;
    }
}
