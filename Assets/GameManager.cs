using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public List<GameObject> objects;
    public float innerRadius = 4.0f, radius = 7.0f, height = 10.0f; // The radius of the circular area
    public float spawnDelay = 10.0f, maxEnemies = 3.0f, currentEnemies = 0.0f;
    public float RealDelay;
    public AudioClip slimeDeathSound;
    public AudioClip whoosh;
    public AudioSource audioSource;

    private void Start()
    {
        StartCoroutine("SpawnObject");
        currentEnemies = 0;
        score = 0;
    }
    private void Update()
    {
        if (currentEnemies < maxEnemies)
        {
            RealDelay = spawnDelay;
            SpawnObjectsInCircularArea();
        }
        else
        {
            RealDelay = 9999999;
        }
    }
    private IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(RealDelay);
        SpawnObjectsInCircularArea();
        StartCoroutine("SpawnObject");
    }

    public void SpawnObjectsInCircularArea()
    {
        float angle = Random.Range(0, 360); // Calculate the angle for each object
        float radiusRandomized = radius * (UnityEngine.Random.Range(0,10))/8 + innerRadius;
        Vector3 spawnPosition = transform.position + Quaternion.Euler(0f, angle, 0f) * (Vector3.forward * radiusRandomized) + (Vector3.up * height);
        GameObject temp = Instantiate(objects[Random.Range(0, objects.Count)], spawnPosition, Quaternion.identity, gameObject.transform);
        temp.transform.rotation = Quaternion.LookRotation((transform.position - temp.transform.position).normalized);
        currentEnemies++;
    }

    public void PlaySlimeDeathSound()
    {
        audioSource.PlayOneShot(slimeDeathSound);
    }
    public void whooshsound()
    {
        audioSource.PlayOneShot(whoosh);
    }
}