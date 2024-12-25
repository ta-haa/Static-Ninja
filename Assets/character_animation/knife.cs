using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    public void oll()
    {
        // Öldü diyelim, burada düşmanı yok etmek için:
        Destroy(gameObject); // Düşmanı yok et
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("bull1")) // Eğer karaktere çarparsa
        {
            oll();
        }
        else if (collision.gameObject.CompareTag("enemies1")) // Eğer ateşe çarparsa
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
        else if (collision.gameObject.CompareTag("yer")) // Eğer lazere çarparsa
        {
            oll();
        }
    }
}


