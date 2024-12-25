using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_hole_script : MonoBehaviour
{

    public void oll()
    {
        Destroy(gameObject); // Düşmanı yok et
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player")) // Eğer karaktere çarparsa
        {
            oll();
        }
        else if (collision.gameObject.CompareTag("fire")) // Eğer ateşe çarparsa
        {
            oll();
        }
        else if (collision.gameObject.CompareTag("knife")) // Eğer bıçağa çarparsa
        {
            oll();
        }
        else if (collision.gameObject.CompareTag("shield")) // Eğer kalkana çarparsa
        {
            oll();
        }
        else if (collision.gameObject.CompareTag("clone")) // Eğer klona çarparsa
        {
            oll();
        }
        else if (collision.gameObject.CompareTag("simsek")) // Eğer simseğe çarparsa
        {
            oll();
        }
        else if (collision.gameObject.CompareTag("laser")) // Eğer lazere çarparsa
        {
            oll();
        }
        else if (collision.gameObject.CompareTag("my_car")) // Eğer lazere çarparsa
        {
            oll();
        }
    }
}
