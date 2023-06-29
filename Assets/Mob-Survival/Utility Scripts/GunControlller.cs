using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControlller : MonoBehaviour
{
    public Transform muzzleTransform;       // The transform representing the gun's muzzle position
    public GameObject bulletPrefab;         // Prefab of the bullet object
    public float shootForce = 20f;          // Force with which the bullet is shot
    public AudioClip shootSound;            // Sound played when shooting

    public AudioSource audioSource;        // Reference to the AudioSource component

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check for input to shoot with Oculus Quest controller
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,OVRInput.Controller.RTouch))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Create a bullet object at the muzzle position
        GameObject bullet = Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation);

        // Apply a force to shoot the bullet
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = muzzleTransform.forward * shootForce;

        // Play the shoot sound
        audioSource.PlayOneShot(shootSound);
    }
}