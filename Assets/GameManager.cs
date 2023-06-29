using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public List<GameObject> objects;
    public float innerRadius = 15.0f, radius = 5f, height = 10.0f; // The radius of the circular area
    public GameObject target;
    public ChestController chestController;

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
        // float radiusRandomized = radius * random_except_list(8, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
        float radiusRandomized = radius * (UnityEngine.Random.Range(0, 10)) + innerRadius;
        Vector3 spawnPosition = transform.position + Quaternion.Euler(0f, angle, 0f) * (Vector3.forward * radiusRandomized) + (Vector3.up * height);
        GameObject temp = Instantiate(objects[Random.Range(0, objects.Count)], spawnPosition, Quaternion.identity, gameObject.transform);
        temp.transform.rotation = Quaternion.LookRotation((transform.position - temp.transform.position).normalized);
        ZombieController tempController = temp.GetComponent<ZombieController>();
        tempController.target = target;
        tempController.chestController = chestController;
    }
}
