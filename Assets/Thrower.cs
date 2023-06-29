using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    public GameObject hand;
    public float timeInterval = 0.1f; // Time interval to calculate average velocity
    private Vector3 previousPosition, avgVelocity = Vector3.zero;
    private float timer;
    Rigidbody throwingObject;

    private void Start()
    {
        previousPosition = hand.transform.position;
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= timeInterval)
        {
            Vector3 currentPosition = hand.transform.position;
            Vector3 displacement = currentPosition - previousPosition;
            Vector3 averageVelocity = displacement / timer;

            avgVelocity = averageVelocity;
            previousPosition = currentPosition;
            timer = 0f;
        }
    }

    public void BeginThrow(GameObject throwing)
    {
        throwingObject = throwing.GetComponent<Rigidbody>();
        Debug.Log("Throwing");
    }

    public void Throw()
    {
        if(throwingObject != null)
        {
            throwingObject.velocity = avgVelocity;
            Debug.Log("Throw");
        }
    }
}

