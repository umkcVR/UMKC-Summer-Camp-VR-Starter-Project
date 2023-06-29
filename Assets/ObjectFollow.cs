using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform player;
    private Transform myTransform;
    public Transform box;
    private Quaternion boxRotation;

    private void Start()
    {
        myTransform = transform;
    }

    private void Update()
    {
        if (pointA != null && pointB != null)
        {
            Vector3 middlePoint = (pointA.position + pointB.position) / 2f;
            myTransform.position = middlePoint;
            Vector3 playerDirection = player.position - middlePoint;
            Quaternion boxRotation = Quaternion.LookRotation(playerDirection);
            Vector3 eulerRotation = boxRotation.eulerAngles;
            eulerRotation.x = 0f; // Set rotation around x-axis to 0
            eulerRotation.z = 0f; // Set rotation around z-axis to 0
            boxRotation = Quaternion.Euler(eulerRotation);
            box.rotation = boxRotation;
        }

    }
}
