using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paraaldim : MonoBehaviour
{
    // Reference to the AudioSource component
    public AudioSource audioSource;

    // Reference to the AudioClip you want to play
    public AudioClip soundEffect;

    public void oll()
    {
        // Play the sound effect
        if (audioSource != null && soundEffect != null)
        {
            audioSource.PlayOneShot(soundEffect);
        }

        // Destroy the object (enemy)
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // If the player collides with the enemy
        {
            oll();
        }
    }
}
