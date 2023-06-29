using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;    // Prefab of the zombie object
    public GameObject target;
    public Transform[] spawnPoints;    // Array of spawn points where zombies can be generated
    public float spawnInterval = 3f;   // Time interval between zombie spawns

    private float spawnTimer;          // Timer to track the spawn interval

    void Start()
    {
        spawnTimer = spawnInterval;
    }

    void Update()
    {
        // Update the spawn timer
        spawnTimer -= Time.deltaTime;

        // Check if it's time to spawn a zombie
        if (spawnTimer <= 0f)
        {
            SpawnZombie();
            spawnTimer = spawnInterval;  // Reset the spawn timer
        }
    }

    void SpawnZombie()
    {
        // Randomly select a spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instantiate a zombie at the spawn point
        GameObject temp = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
        ZombieController tempController = temp.GetComponent<ZombieController>();
        tempController.target = target;
    }
}