using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lowerer : MonoBehaviour
{
    public float loweringSpeed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * loweringSpeed * Time.deltaTime;
    }
}
