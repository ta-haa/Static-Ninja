using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowEnemiesFire : MonoBehaviour
{
    public GameObject firePrefab; // Fire prefab reference
    public Transform fireSpawnPoint; // Point where the fire will be thrown from

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(DestroyEnemyAfterDelay(10f)); // Start the coroutine
        StartCoroutine(ThrowKnifeEveryTwoSeconds()); // Start the knife throwing coroutine
    }

    private IEnumerator DestroyEnemyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject); // Destroy the enemy after the delay
    }

    private IEnumerator ThrowKnifeEveryTwoSeconds()
    {
        while (true) // Infinite loop
        {
            ThrowKnife();
            yield return new WaitForSeconds(2f); // Wait for 2 seconds
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
