using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Enemy;
    public float Timer = 0;
    public float SpawnFrequency = 10;
    public float MaxEnemies = 5;
    public float CurrentEnemies = 0;
    public float SpawnRad = 50;

    void Start()
    {
        
    }

    void Update()
    {
        Spawn();
        Timer = Timer + Time.deltaTime;
    }

    void Spawn()
    {
        if (Timer >= SpawnFrequency && CurrentEnemies < MaxEnemies)
        {
            Instantiate(Enemy, new Vector3(Random.Range(-SpawnRad, SpawnRad), transform.position.y,Random.Range(-SpawnRad, SpawnRad)), transform.rotation);
            Debug.Log("Enemy Spawned");
            Timer = 0;
        }
    }
}
