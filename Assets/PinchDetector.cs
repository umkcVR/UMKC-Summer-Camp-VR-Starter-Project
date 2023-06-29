using UnityEngine;
using UnityEngine.Events;

public class PinchDetector : MonoBehaviour
{
    public Transform object1; // Reference to the first game object
    public Transform object2; // Reference to the second game object

    public float epsilon = 0.1f; // Distance threshold for triggering the event

    public UnityEvent onObjectsWithinDistance; // Unity event to be invoked when objects are within distance

    private void Update()
    {
        Debug.Log(Vector3.Distance(object1.localToWorldMatrix.lossyScale, object2.localToWorldMatrix.lossyScale));
        // Check if the objects are within epsilon distance
        if (Vector3.Distance(object1.position, object2.position) <= epsilon)
        {
            // Invoke the Unity event
            onObjectsWithinDistance.Invoke();
        }
    }
}
