using UnityEngine;
using UnityEngine.XR;

public class BoxCollectorVR : MonoBehaviour
{
    public float boxHeightOffset = 1.5f; // height offset for the box to match player's standing height
    public float boxMoveSpeed = 0.1f; // speed of the box movement
    public float boxMaxDistance = 5f; // maximum distance the box can move from its starting position
    public GameObject collectedObjectPrefab; // prefab for the collected objects
    public GameObject[] fallingObjectPrefabs; // array of prefabs for the falling objects
    public float spawnInterval = 2f; // interval between spawns
    public float spawnRadius = 2f; // radius around the box where objects can spawn

    private int score = 0; // current score
    private float spawnTimer = 0f; // timer for spawning objects
    private Vector3 boxStartPosition; // starting position of the box

    void Start()
    {
        // record the starting position of the box
        boxStartPosition = transform.position;
    }

    void Update()
    {
        // get the position of the VR headset and move the box to match
        Vector3 headsetPosition = InputTracking.GetLocalPosition(XRNode.Head);
        Vector3 boxPosition = new Vector3(headsetPosition.x, boxHeightOffset, headsetPosition.z);

        // calculate the distance between the box and its starting position
        float distanceFromStart = Vector3.Distance(boxPosition, boxStartPosition);

        // move the box if it is within the maximum distance from its starting position
        if (distanceFromStart <= boxMaxDistance)
        {
            Vector3 boxMovement = (boxPosition - transform.position).normalized * boxMoveSpeed;
            transform.position += boxMovement;
        }

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

        // spawn a new collected object at a random position within the maximum distance from the box's starting position
        Vector3 position = boxStartPosition + Random.insideUnitSphere * boxMaxDistance;
        Instantiate(collectedObjectPrefab, position, Quaternion.identity);
    }
}