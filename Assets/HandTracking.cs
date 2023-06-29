using UnityEngine;
using UnityEngine.Events;
using Oculus;

public class HandTracking : MonoBehaviour
{
    public UnityEvent OnIndexFingerPoint;

    private OVRHand ovrHand;

    private void Start()
    {
        ovrHand = GetComponent<OVRHand>();
    }

    private void Update()
    {
        if (ovrHand != null && ovrHand.IsTracked)
        {
            if (ovrHand.GetFingerIsPinching(OVRHand.HandFinger.Index))
            {
                // Index finger is pinching (pointing)
                OnIndexFingerPoint?.Invoke();
            }
        }
    }
}
