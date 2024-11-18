using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Enemies : MonoBehaviour
{
    public GameObject firePrefab; // Fire prefab reference
    public Transform fireSpawnPoint; // Point where the fire will be thrown from

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(ThrowKnifeEveryRandomSeconds()); // Start the knife throwing coroutine
    }

    private IEnumerator ThrowKnifeEveryRandomSeconds()
    {
        while (true) // Infinite loop
        {
            ThrowKnife();
            float randomWaitTime = Random.Range(2f, 4f); // Get a random wait time between 2 and 4 seconds
            yield return new WaitForSeconds(randomWaitTime); // Wait for the random duration
        }
    }

    private void ThrowKnife()
    {
        // Create a new instance of the fire prefab
        GameObject fire = Instantiate(firePrefab, fireSpawnPoint.position, Quaternion.identity);

        // Get the Rigidbody2D component of the fire
        Rigidbody2D fireRb = fire.GetComponent<Rigidbody2D>();

        // Apply a force to throw the fire
        fireRb.velocity = new Vector2(-10f, 0f); // Throw the fire to the left
    }
}
