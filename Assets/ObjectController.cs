using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float lifeTime = 5.0f;

    private void Awake()
    {
        Debug.Log("Calling Wait to destroy");
        StartCoroutine("WaitToDelete");
    }

    private IEnumerator WaitToDelete() 
    {
        yield return new WaitForSeconds(lifeTime);
        Debug.Log("destroy" + gameObject.name);
        Destroy(gameObject);
    }
}
