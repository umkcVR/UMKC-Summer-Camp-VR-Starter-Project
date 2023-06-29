using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float destroyDelay = 3f;      // Delay before destroying the bullet
    public GameObject hitEffectPrefab;   // Prefab of the hit effect to instantiate

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet collision");
        // Check if the collision is with a zombie
        if (collision.gameObject.CompareTag("Zombie"))
        {
            // Instantiate hit effect at the collision point
            Instantiate(hitEffectPrefab, collision.contacts[0].point, Quaternion.identity);

            ZombieController tempController = collision.gameObject.GetComponent<ZombieController>();
            tempController.Die();

            // Destroy the zombie object after the delay
            Destroy(collision.gameObject, destroyDelay);

            // Destroy the bullet object immediately
            Destroy(gameObject);
        }
    }
}