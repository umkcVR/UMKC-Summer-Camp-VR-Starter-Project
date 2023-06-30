using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        gameObject.transform.position = target.transform.position;
        gameObject.transform.rotation = target.transform.rotation;
    }
}
