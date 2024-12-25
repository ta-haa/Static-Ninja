using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
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

    public GameObject laserPrefab; // laser prefab'ı referansı
    public Transform laserSpawnPoint; // laser fırlatılacağı nokta
    public GameObject lightPrefab; // lightning prefab'ı referansı
    public Transform lightSpawnPoint; // lightning fırlatılacağı nokta
    public GameObject portalPrefab; // portal prefab'ı referansı
    public Transform portalSpawnPoint; // portal fırlatılacağı nokta


    public GameObject firePrefab; // Ateş prefab'ı referansı
    public Transform fireSpawnPoint; // Ateşin fırlatılacağı nokta
    public GameObject shieldPrefab; // Kalkan prefab'ı referansı
    private GameObject currentShield; // Aktif kalkan referansı

    public GameObject clonePrefab; // character clone prefab'ı referansı
    public Transform cloneSpawnPoint; // character clone spawn point

    public AudioSource audioSource; // AudioSource bileşeni
    public AudioClip musicClip; // Müzik dosyası
    public AudioClip laserMusicClip; // Müzik dosyası for laser
    public AudioClip jumpMusicClip;  // Müzik dosyası for jump 

    public GameObject[] arabaPrefabs; // 5 araba prefab'ı referansı
    private GameObject arabacurrent; // Aktif araba referansı

    public GameObject[] karakterPrefabs; // 5 karakter prefab'ı referansı
    private GameObject karaktercurrent; // Aktif karakter referansı


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileşenini al
        animator = GetComponent<Animator>(); // Animator bileşenini al

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>(); // AudioSource bileşenini al
        }

        // Eğer araba prefab'ları atanmadıysa hata ver
        if (arabaPrefabs.Length == 0)
        {
            Debug.LogError("Araba prefab'ları array'i boş!");
        }
        // Eğer karakter prefab'ları atanmadıysa hata ver
        if (karakterPrefabs.Length == 0)
        {
            Debug.LogError("karakter prefab'ları array'i boş!");
        }
    }


    void Update()
    {
        // Zıplama ve alçalmayı kontrol et
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            Jump();
            PlayMusicJump(); // Jump müziğini çal
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

        // Space tuşuna basıldığında clone oluştur
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ClonePlayer();
        }

        // B tuşuna basıldığında Portal oluştur ve müzik çal
        if (Input.GetKeyDown(KeyCode.B))
        {
            PortalPlayer();
        }

        // H tuşuna basıldığında Laser oluştur ve müzik çal
        if (Input.GetKeyDown(KeyCode.H))
        {
            LaserPlayer();
            PlayMusicLaser(); // Laser müziğini çal
        }

        // G tuşuna basıldığında Lightning oluştur
        if (Input.GetKeyDown(KeyCode.G))
        {
            LightPlayer();
            PlayMusicyildirim(); // Yıldırım müziğini çal
        }
        // K tuşuna basıldığında Lightning oluştur
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(Activatearaba());
        }
        // P tuşuna basıldığında Lightning oluştur
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(Activatekarakter());
        }

        MoveRight();
    }


    // Müzik çalma fonksiyonu
    public void PlayMusicyildirim()
    {
        if (audioSource != null && musicClip != null)
        {
            // Müzik çalmaya başla
            if (!audioSource.isPlaying)
            {
                audioSource.clip = musicClip; // AudioClip'i ayarla
                audioSource.Play(); // Müzik çalmaya başla
            }
        }
    }
    public void PlayMusicLaser()
    {
        if (audioSource != null && laserMusicClip != null)
        {
            // Müzik çalmaya başla, ama eğer zaten çalıyorsa tekrar çalma
            if (!audioSource.isPlaying)
            {
                audioSource.clip = laserMusicClip; // AudioClip'i ayarla
                audioSource.Play(); // Müzik çalmaya başla
            }
        }
    }

    public void PlayMusicJump()
    {
        if (audioSource != null && jumpMusicClip != null)
        {
            // Müzik çalmaya başla, ama eğer zaten çalıyorsa tekrar çalma
            if (!audioSource.isPlaying)
            {
                audioSource.clip = jumpMusicClip; // AudioClip'i ayarla
                audioSource.Play(); // Müzik çalmaya başla
            }
        }
    }

    public void LightPlayer()
    {
        // Lightning prefab'ından yeni bir örnek oluştur
        GameObject light = Instantiate(lightPrefab, lightSpawnPoint.position, Quaternion.identity);
        // Lightning Rigidbody2D bileşenini al
        Rigidbody2D lightRb = light.GetComponent<Rigidbody2D>();
        // Lightning'i fırlatmak için kuvvet uygula
        lightRb.velocity = new Vector2(1f, 0f); // Sağa doğru fırlat
    }

    public void LaserPlayer()
    {
        // Laser prefab'ından yeni bir örnek oluştur
        GameObject laser = Instantiate(laserPrefab, laserSpawnPoint.position, Quaternion.identity);
        // Laser Rigidbody2D bileşenini al
        Rigidbody2D laserRb = laser.GetComponent<Rigidbody2D>();
        // Laser'i fırlatmak için kuvvet uygula
        laserRb.velocity = new Vector2(100f, 0f); // Sağa doğru fırlat
    }

    public void PortalPlayer()
    {
        // Portal prefab'ından yeni bir örnek oluştur
        GameObject portal = Instantiate(portalPrefab, portalSpawnPoint.position, Quaternion.identity);
    }

    public void ClonePlayer()
    {
        // Clone prefab'ından yeni bir örnek oluştur
        GameObject clone = Instantiate(clonePrefab, cloneSpawnPoint.position, Quaternion.identity);
        // Clone Rigidbody2D bileşenini al
        Rigidbody2D cloneRb = clone.GetComponent<Rigidbody2D>();
        // Clone'u fırlatmak için kuvvet uygula
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

    public IEnumerator Activatearaba()
    {
        if (arabacurrent == null) // Araba aktif değilse
        {
            // Karakterin renderer'ını gizle
            SpriteRenderer characterRenderer = GetComponent<SpriteRenderer>();
            if (characterRenderer != null)
            {
                characterRenderer.enabled = false;
            }

            // Rastgele bir araba seç
            int randomIndex = Random.Range(0, arabaPrefabs.Length); // 0 ile arabaPrefabs.Length-1 arasında rastgele bir sayı seç
            GameObject selectedCar = arabaPrefabs[randomIndex]; // Seçilen arabayı al

            // Araba prefab'ını instantiate et
            Vector3 spawnPosition = transform.position + new Vector3(2f, 0f, 0f); // X ekseninde +2 birim
            arabacurrent = Instantiate(selectedCar, spawnPosition, Quaternion.identity); // Araba prefab'ını yerleştir
            arabacurrent.SetActive(true); // Arabayı aktif hale getir

            // Arabayı karakterle birlikte hareket ettir
            arabacurrent.transform.SetParent(transform); // Araba, karakterin çocuğu olacak
            arabacurrent.transform.localPosition = new Vector3(2f, 0.5f, 0f); // Araba, karakterin biraz önünde

            // 4 saniye bekle
            yield return new WaitForSeconds(4f);

            // Araba yok et
            Destroy(arabacurrent);
            arabacurrent = null;

            // Karakteri tekrar görünür yap
            if (characterRenderer != null)
            {
                characterRenderer.enabled = true;
            }
        }
    }

    public IEnumerator Activatekarakter()
    {
        if (karaktercurrent == null) // karakter aktif değilse
        {
            // Karakterin renderer'ını gizle
            SpriteRenderer characterRenderer = GetComponent<SpriteRenderer>();
            if (characterRenderer != null)
            {
                characterRenderer.enabled = false;
            }

            // Rastgele bir karakter seç
            int randomIndex = Random.Range(0, karakterPrefabs.Length); // 0 ile karakterPrefabs.Length-1 arasında rastgele bir sayı seç
            GameObject selectedCar = karakterPrefabs[randomIndex]; // Seçilen karakteryı al

            // karakter prefab'ını instantiate et
            Vector3 spawnPosition = transform.position + new Vector3(2f, 0f, 0f); // X ekseninde +2 birim
            karaktercurrent = Instantiate(selectedCar, spawnPosition, Quaternion.identity); // karakter prefab'ını yerleştir
            karaktercurrent.SetActive(true); // karakter aktif hale getir

            // karakteryı karakterle birlikte hareket ettir
            karaktercurrent.transform.SetParent(transform); // karakter, karakterin çocuğu olacak
            karaktercurrent.transform.localPosition = new Vector3(2f, 0.5f, 0f); // karakter, karakterin biraz önünde

            // 4 saniye bekle
            yield return new WaitForSeconds(4f);

            // karakter yok et
            Destroy(karaktercurrent);
            karaktercurrent = null;

            // Karakteri tekrar görünür yap
            if (characterRenderer != null)
            {
                characterRenderer.enabled = true;
            }
        }
    }


    public void ThrowKnife()
    {
        // Ateş prefab'ından yeni bir örnek oluştur
        GameObject knife = Instantiate(knifePrefab, knifeSpawnPoint.position, Quaternion.identity);
        // Ateşin Rigidbody2D bileşenini al
        Rigidbody2D knifeRb = knife.GetComponent<Rigidbody2D>();
        // Ateşi fırlatmak için kuvvet uygula
        knifeRb.velocity = new Vector2(30f, 0f); // Sağa doğru fırlat
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

    // Çarpma olayları
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("UpperGround") || collision.gameObject.CompareTag("yer"))
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
