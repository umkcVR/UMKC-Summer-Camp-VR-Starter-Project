using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public List<GameObject> objects;
    public float radius = 5f, height = 10.0f; // The radius of the circular area

    private void Start()
    {
        StartCoroutine("SpawnObject");
    }

    private IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(1.0f);
        SpawnObjectsInCircularArea();
        StartCoroutine("SpawnObject");
    }

    public void SpawnObjectsInCircularArea()
    {
        float angle = Random.Range(0, 360); // Calculate the angle for each object
        Vector3 spawnPosition = transform.position + Quaternion.Euler(0f, angle, 0f) * (Vector3.forward * radius) + (Vector3.up * height);
        Instantiate(objects[Random.Range(0, objects.Count)], spawnPosition, Quaternion.identity, gameObject.transform);
    }
}
