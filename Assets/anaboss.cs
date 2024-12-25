using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anaboss : MonoBehaviour
{
    public GameObject solanafirePrefab; // anafire prefab reference
    public Transform anafireSpawnPoint; // Point where the anafire will be thrown from

    public GameObject saganafirePrefab; // saganafire prefab reference

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(ThrowFireEveryRandomSeconds()); // Start the fire throwing coroutine
    }

    private IEnumerator ThrowFireEveryRandomSeconds()
    {
        while (true) // Infinite loop
        {
            ThrowFire(); // Call the throw fire method
            float randomWaitTime = Random.Range(0.5f, 2f); // Get a random wait time between 2 and 4 seconds
            yield return new WaitForSeconds(randomWaitTime); // Wait for the random duration
        }
    }

    private void ThrowFire()
    {
        // Decide which prefab to use (randomly)
        GameObject firePrefabToThrow;
        Vector2 throwDirection;

        // Randomly choose between solanafire or saganafire
        if (Random.value > 0.5f)
        {
            firePrefabToThrow = solanafirePrefab;
            throwDirection = new Vector2(-5f, 0f); // Left direction for solanafire
        }
        else
        {
            firePrefabToThrow = saganafirePrefab;
            throwDirection = new Vector2(5f, 0f); // Right direction for saganafire
        }

        // Create a new instance of the chosen fire prefab
        GameObject fire = Instantiate(firePrefabToThrow, anafireSpawnPoint.position, Quaternion.identity);

        // Get the Rigidbody2D component of the fire
        Rigidbody2D fireRb = fire.GetComponent<Rigidbody2D>();

        // Apply the force to throw the fire
        fireRb.velocity = throwDirection;
    }
}
