using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObjectAndScore : MonoBehaviour
{
    public int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Objects"))
        {
            Destroy(other.gameObject);
            Debug.Log("Score");
            score++;
        }
    }
}
