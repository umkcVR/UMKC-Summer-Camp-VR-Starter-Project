using UnityEngine;

public class BoxCollectorVR : MonoBehaviour
{
    public float speed = 10f; // speed of the box movement
    public float boxWidth = 1f; // width of the box
    public float boxHeight = 1f; // height of the box
    public GameObject collectedObjectPrefab; // prefab for the collected objects
    public GameObject[] fallingObjectPrefabs; // array of prefabs for the falling objects
    public float spawnInterval = 2f; // interval between spawns
    public float spawnRadius = 2f; // radius around the box where objects can spawn
    public float boxHeightOffset = 1.5f; // height offset for the box to match player's standing height

    private int score = 0; // current score
    private float spawnTimer = 0f; // timer for spawning objects

    void Update()
    {
        // get the position of the VR headset and move the box to match
        Vector3 headsetPosition = InputTracking.GetLocalPosition(XRNode.Head);
        transform.position = new Vector3(headsetPosition.x, boxHeightOffset, headsetPosition.z);

        // spawn falling objects at random intervals
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            int randomIndex = Random.Range(0, fallingObjectPrefabs.Length);
            Instantiate(fallingObjectPrefabs[randomIndex], spawnPosition, Quaternion.identity);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // destroy the collected object and increase the score
        Destroy(other.gameObject);
        score++;

        // spawn a new collected object at a random position
        Vector3 position = new Vector3(Random.Range(-boxWidth / 2f, boxWidth / 2f), boxHeight, Random.Range(-boxHeight / 2f, boxHeight / 2f));
        Instantiate(collectedObjectPrefab, position, Quaternion.identity);
    }
}