using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class Heart : MonoBehaviour
{

    public int maxHealth = 3; // Inspector'dan ayarlanabilir
    public int damageAmount = 1; // Hasar miktarını ayarlamak için
    public int extralife = 1;
    private int currentHealth;
    public Image[] heartImages; // Kırmızı ve gri kalp için Image bileşenleri 
    private Animator animator;

    // Reklam script'i için referans
    private reklam adManager2;

    // AudioSource ve AudioClip referansları
    public AudioSource audioSource;
    public AudioClip gameOverSound;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHearts();
        animator = GetComponent<Animator>();

        // Reklam yöneticisini buluyoruz
        adManager2 = FindObjectOfType<reklam>(); // Eğer "reklam" script'i sahnede bir GameObject'e eklenmişse, onu bulur

        // Reklamı yükle
        if (adManager2 != null)
        {
            // adManager2.LoadInterstitialAd(); // Başlangıçta reklam yükle
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("bull2") || other.CompareTag("bull1") || other.CompareTag("enemies1"))
        {
            TakeDamage(); // Hasar al
        }
        else if (other.CompareTag("extra_life"))
        {
            extra_life(); // +1 can ekle
        }
    }

    public void SetHealth(int health)
    {
        currentHealth = Mathf.Clamp(health, 0, maxHealth); // Sağlık değeri maxHealth'ı geçmesin
        UpdateHearts(); // Sağlık değerini günceller
    }

    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageAmount; // Hasar miktarını çıkar
            UpdateHearts();

            // Telefonu titreştirme
            Handheld.Vibrate(); // Cihaz titreşimi

            // Hasar alma animasyonunu başlat
            if (animator != null)
            {
                animator.SetBool("isDamaged", true);
            }
        }
        else
        {
            // Can sıfır olduğunda
            Debug.Log("Canınız kalmadı!");

            // Oyun bitti sesi çal
            if (audioSource != null && gameOverSound != null)
            {
                audioSource.PlayOneShot(gameOverSound); // Game over sesini çal
            }

            // Reklam gösterme 
            if (adManager2 != null)
            {
                // adManager2.OnCharacterDeath(); // Reklam göster
            }

            // İleriye yönelik bir şey yapmak isterseniz: Yeniden başlatmak için 
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void extra_life()
    {
        // Ekstra hayat ekleme
        if (currentHealth < maxHealth) // Can doluysa ekstra hayat ekleme
        {
            currentHealth += extralife; // +1 hayat ekle
            currentHealth = Mathf.Min(currentHealth, maxHealth); // Canı maxHealth'dan büyük yapma
            UpdateHearts();
        }
    }

    public void ResetDamageAnimation()
    {
        if (animator != null)
        {
            animator.SetBool("isDamaged", false);
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (heartImages[i] != null)
            {
                // Eğer sağlık değeri varsa, kalbi dolu yap
                heartImages[i].color = (i < currentHealth) ? Color.white : new Color32(56, 56, 56, 255);
            }
            else
            {
                Debug.LogError($"Kalp Nesnesi {i} Image bileşenine sahip değil.");
            }
        }
    }

    // Sağlık artışı veya kaybı sırasında animasyonu zamanlayabilmek için gecikme ekleyebiliriz
    IEnumerator PlayDamageAnimationWithDelay()
    {
        animator.SetBool("isDamaged", true);
        yield return new WaitForSeconds(0.5f); // Hasar animasyonunun süresi
        ResetDamageAnimation();
    }

}
