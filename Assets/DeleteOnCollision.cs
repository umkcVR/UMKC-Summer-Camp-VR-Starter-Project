using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnCollision : MonoBehaviour
{
    public GameManager gameManager;

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
                gameManager.PlaySlimeDeathSound();
            }
        }
    }
}
