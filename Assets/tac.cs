using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tac : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Karakterin objesiyle çarpma kontrolü
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject); // tacı yok et 
        }
    }
}
