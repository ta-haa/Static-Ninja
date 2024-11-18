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
        speed = Random.Range(0.5f, 3f); // Hızı rastgele bir değerle ayarla
    }

    void Update()
    {
        // Düşmanın sola doğru hareket etmesini sağla
        transform.Translate(Vector3.left * speed * Time.deltaTime);


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("UpperGround"))
        {
            animator.SetBool("isGrounded", true); // Yerde olduğunda zemin animasyonunu tetikle
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("UpperGround"))
        {
            animator.SetBool("isGrounded", false); // Yerde olmadığında zemin animasyonunu durdur
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("fire") || other.CompareTag("knife") || other.CompareTag("shield") || other.CompareTag("clone"))
        {
            Destroy(gameObject); // Düşmanı yok et 
        }
    }
}
