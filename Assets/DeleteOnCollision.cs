using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnCollision : MonoBehaviour
{
    public GameManager gameManager;
    public ParticleScript ps;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Slime"))
        {
            if(gameManager != null)
            {
                foreach (Transform child in collision.transform)
                {
                    Destroy(child.gameObject);
                }
                Destroy(collision.transform.gameObject);
                gameManager.score++;
                gameManager.currentEnemies--;
                ps.EmitBurst();
                gameManager.PlaySlimeDeathSound();
            }
        }
    }
}
