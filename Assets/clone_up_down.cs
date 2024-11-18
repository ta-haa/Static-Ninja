using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clone_up_down : MonoBehaviour
{
    public Transform upperGround; // Üst zemin referansı
    public float lowerGroundY = 0f; // Alt zemin Y pozisyonu
    private Rigidbody2D rb;
    public float maxSpeed = 10f; // Maksimum hız  
    public float moveSpeed = 5f; // Hareket hızı
    public float jumpHeight = 20f; // Zıplama yüksekliği
    private Animator animator; // Animator bileşeni
    private bool isJumping = false; // Zıplama durumu
    private bool isGrounded = true; // Yerde olma durumu

    public GameObject knifePrefab; // Bıçak prefab'ı referansı
    public Transform knifeSpawnPoint; // Bıçağın fırlatılacağı nokta

    public GameObject shieldPrefab; // Kalkan prefab'ı referansı
    public GameObject firePrefab; // Ateş prefab'ı referansı
    public Transform fireSpawnPoint; // Ateşin fırlatılacağı nokta

    private GameObject currentShield; // Aktif kalkan referansı

    public GameObject clonePrefab; // character clone prefab'ı referansı
    public Transform cloneSpawnPoint; // character clone spawn point

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileşenini al
        animator = GetComponent<Animator>(); // Animator bileşenini al
    }

    void Update()
    {
        // Zıplama ve alçalmayı kontrol et
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(ActivateShield());
        }

        // Sağ ok tuşuna basıldığında bıçak fırlat
        if (Input.GetKey(KeyCode.RightArrow))
        {
            ThrowKnife();
        }

        // Sol ok tuşuna basıldığında ateş fırlat
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ThrowFire();
        }

        // space tuşuna basıldığında clone oluştur
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ClonePlayer();
        }

        MoveRight();
    }
    public void ClonePlayer()
    {
        // clone prefab'ından yeni bir örnek oluştur
        GameObject clone = Instantiate(clonePrefab, cloneSpawnPoint.position, Quaternion.identity);
        // clone Rigidbody2D bileşenini al
        Rigidbody2D cloneRb = clone.GetComponent<Rigidbody2D>();
        // clone fırlatmak için kuvvet uygula
        cloneRb.velocity = new Vector2(20f, 0f); // Sağa doğru fırlat
    }
    private void MoveRight()
    {
        // X ekseninde hareket et
        float newVelocityX = Mathf.Clamp(rb.velocity.x + moveSpeed * Time.deltaTime, 0, maxSpeed);
        rb.velocity = new Vector2(newVelocityX, rb.velocity.y); // Sağa doğru hareket et

        // Animasyonu oynat
        animator.SetBool("isMoving", true);
    }

    public void Jump()
    {
        isJumping = true;
        isGrounded = false;
        animator.SetBool("isJumping", true); // Zıplama animasyonunu başlat
        float jumpForce = Mathf.Sqrt(4 * Mathf.Abs(Physics2D.gravity.y) * jumpHeight); // Zıplama kuvvetini hesapla
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Zıplama kuvveti ekle

        // Zıplama durumunu sıfırlamak için bekle
        StartCoroutine(ResetJump());
    }

    public IEnumerator ResetJump()
    {
        // Zıplama animasyonunu bekle
        yield return new WaitForSeconds(1f);

        // Zıplama durumunu sıfırla
        isJumping = false;
        animator.SetBool("isJumping", false); // Zıplama animasyonunu durdur
        if (isGrounded)
        {
            animator.SetBool("isGrounded", true); // Yerde olduğunda zemin animasyonunu tetikle
        }
    }

    public IEnumerator ActivateShield()
    {
        if (currentShield == null) // Kalkan aktif değilse
        {
            currentShield = Instantiate(shieldPrefab, transform.position, Quaternion.identity, transform); // Kalkanı karakterin altına yerleştir
            currentShield.SetActive(true); // Kalkanı aktif hale getir

            // 5 saniye bekle
            yield return new WaitForSeconds(5f);

            // 5 saniye sonra kalkanı yok et
            Destroy(currentShield);
            currentShield = null; // Kalkan referansını sıfırla
        }
    }

    public void ThrowKnife()
    {
        // Bıçak prefab'ından yeni bir örnek oluştur
        GameObject knife = Instantiate(knifePrefab, knifeSpawnPoint.position, Quaternion.identity);
        // Bıçağın Rigidbody2D bileşenini al
        Rigidbody2D knifeRb = knife.GetComponent<Rigidbody2D>();
        // Bıçağı fırlatmak için kuvvet uygula
        knifeRb.velocity = new Vector2(20f, 0f); // Sağa doğru fırlat
    }

    public void ThrowFire()
    {
        // Ateş prefab'ından yeni bir örnek oluştur
        GameObject fire = Instantiate(firePrefab, fireSpawnPoint.position, Quaternion.identity);
        // Ateşin Rigidbody2D bileşenini al
        Rigidbody2D fireRb = fire.GetComponent<Rigidbody2D>();
        // Ateşi fırlatmak için kuvvet uygula
        fireRb.velocity = new Vector2(20f, 0f); // Sağa doğru fırlat
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("UpperGround"))
        {
            isGrounded = true; // Yerde olduğunu işaretle
            rb.gravityScale = 1; // Yer çekimini normal hale getir
            animator.SetBool("isGrounded", true); // Yerde olduğunda zemin animasyonunu tetikle
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
}
