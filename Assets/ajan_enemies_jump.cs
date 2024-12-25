using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ajan_enemies_jump : MonoBehaviour
{
    public float jumpHeight = 1f; // Zıplama yüksekliği
    public float speed; // Düşmanın hızı
    private bool isJumping = false; // Zıplama durumu
    private bool isGrounded = true; // Yerde olma durumu
    private Rigidbody2D rb; // Rigidbody2D bileşeni
    private Animator animator; // Animator bileşeni

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileşenini al
        animator = GetComponent<Animator>(); // Animator bileşenini al
        speed = Random.Range(0.5f, 1f); // Hızı rastgele bir değerle ayarla
    }

    void Update()
    {
        // Düşmanın sola doğru hareket etmesini sağla
        transform.Translate(Vector3.left * speed * Time.deltaTime);



        // Zıplama yap
        if (isGrounded && !isJumping)
        {
            Jump();
        }



    }

    private void Jump()
    {
        isJumping = true;
        isGrounded = false;
        float jumpForce = Mathf.Sqrt(5f * Mathf.Abs(Physics2D.gravity.y) / jumpHeight); // Zıplama kuvvetini hesapla
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Zıplama kuvveti ekle

        // Zıplama tamamlandıktan sonra yere dönecek
        StartCoroutine(ResetJump());
    }














    /*
        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Collision2D tipindeki parametreyi kullanarak çarpışan nesneye erişiyoruz.
            // Bu nesnenin tag'ini kontrol ediyoruz.

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
        }

    */


    public void oll()
    {
        // Öldü diyelim, burada düşmanı yok etmek için:
        Destroy(gameObject); // Düşmanı yok et
    }









    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("UpperGround"))
        {
            isGrounded = true; // Yerde olduğunu işaretle
            rb.gravityScale = 1; // Yer çekimini normal hale getir
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





    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("UpperGround"))
        {
            isGrounded = false; // Yerden ayrıldığında durumu güncelle
            animator.SetBool("isGrounded", false); // Yerde olmadığında zemin animasyonunu durdur
        }
    }
    /*
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") || other.CompareTag("fire") || other.CompareTag("knife") || other.CompareTag("shield") || other.CompareTag("clone") || other.CompareTag("simsek") || other.CompareTag("laser"))
            {
                Destroy(gameObject); // Düşmanı yok et 
            }
        }
    */
    private IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(0.5f); // Zıplama süresi
        isJumping = false; // Zıplama durumunu sıfırla
    }
}
