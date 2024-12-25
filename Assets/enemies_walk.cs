using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies_walk : MonoBehaviour
{
    public float speed; // Düşmanın hızı
    private Rigidbody2D rb; // Rigidbody2D bileşeni
    private Animator animator; // Animator bileşeni

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileşenini al
        animator = GetComponent<Animator>(); // Animator bileşenini al
        speed = Random.Range(0.5f, 5f); // Hızı rastgele bir değerle ayarla
    }

    void Update()
    {
        // Düşmanın sola doğru hareket etmesini sağla
        transform.Translate(Vector3.left * speed * Time.deltaTime);


    }

    public void oll()
    {
        // Öldü diyelim, burada düşmanı yok etmek için:
        Destroy(gameObject); // Düşmanı yok et
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("UpperGround"))
        {
            animator.SetBool("isGrounded", true); // Yerde olduğunda zemin animasyonunu tetikle
        }

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

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("UpperGround"))
        {
            animator.SetBool("isGrounded", false); // Yerde olmadığında zemin animasyonunu durdur
        }
    }






}





