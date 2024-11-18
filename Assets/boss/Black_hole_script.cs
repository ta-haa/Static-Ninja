using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_hole_script : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("fire")) // Eğer ateşe çarparsa
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("knife")) // Eğer ateşe çarparsa
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("shield")) // Eğer ateşe çarparsa
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("clone")) // Eğer klona çarparsa
        {
            Destroy(gameObject);
        }
    }
}
