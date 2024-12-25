using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dusman : MonoBehaviour
{
    public void Öl()
    {
        // Öldü diyelim, burada düşmanı yok etmek için:
        Destroy(gameObject); // Düşmanı yok et
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Eğer çarpan obje oyuncuysa (player tag'i ile)
        if (collision.gameObject.CompareTag("Player"))
        {
            // Oyuncuya çarptığında düşmanı öldür
            Öl();
        }
        else if (collision.gameObject.CompareTag("simsek"))
        {
            // Oyuncuya çarptığında düşmanı öldür
            Öl();
        }
        else if (collision.gameObject.CompareTag("laser"))
        {
            // Oyuncuya çarptığında düşmanı öldür
            Öl();
        }
        else if (collision.gameObject.CompareTag("clone"))
        {
            // Oyuncuya çarptığında düşmanı öldür
            Öl();
        }
        else if (collision.gameObject.CompareTag("fire"))
        {
            // Oyuncuya çarptığında düşmanı öldür
            Öl();
        }
    }
}
