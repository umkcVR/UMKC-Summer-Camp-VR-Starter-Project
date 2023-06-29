using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObjectAndScore : MonoBehaviour
{
    public GameManager gameManager;
    public AudioSource audioSource;
    public AudioClip clipOne;
    public ParticleSystem particleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Objects"))
        {
            Destroy(other.gameObject);
            Debug.Log("Score");
            gameManager.score++;
            audioSource.PlayOneShot(clipOne);
            particleSystem.Play();
        }
    }
}
