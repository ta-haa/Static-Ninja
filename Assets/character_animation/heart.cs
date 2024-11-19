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
    private reklam adManager;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHearts();
        animator = GetComponent<Animator>();

        // Reklam yöneticisini buluyoruz
        adManager = FindObjectOfType<reklam>(); // Eğer "reklam" script'i sahnede bir GameObject'e eklenmişse, onu bulur

        // Reklamı yükle
        if (adManager != null)
        {
            adManager.LoadInterstitialAd(); // Başlangıçta reklam yükle
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bull1"))
        {
            TakeDamage(); // Hasar al
        }
        else if (other.CompareTag("bull2")) // Eğer   etiketiyle çarparsa
        {
            TakeDamage(); // Hasar al
        }
        else if (other.CompareTag("bull3")) // Eğer   etiketiyle çarparsa
        {
            TakeDamage(); // Hasar al
        }
        else if (other.CompareTag("bull4")) // Eğer   etiketiyle çarparsa
        {
            TakeDamage(); // Hasar al
        }
        else if (other.CompareTag("bull5")) // Eğer   etiketiyle çarparsa
        {
            TakeDamage(); // Hasar al
        }
        else if (other.CompareTag("bull6")) // Eğer   etiketiyle çarparsa
        {
            TakeDamage(); // Hasar al
        }
        else if (other.CompareTag("bull7")) // Eğer   etiketiyle çarparsa
        {
            TakeDamage(); // Hasar al
        }
        else if (other.CompareTag("bull8")) // Eğer   etiketiyle çarparsa
        {
            TakeDamage(); // Hasar al
        }
        else if (other.CompareTag("bull9")) // Eğer   etiketiyle çarparsa
        {
            TakeDamage(); // Hasar al
        }
        else if (other.CompareTag("bull10")) // Eğer   etiketiyle çarparsa
        {
            TakeDamage(); // Hasar al
        }
        else if (other.CompareTag("bull11")) // Eğer   etiketiyle çarparsa
        {
            TakeDamage(); // Hasar al
        }
        else if (other.CompareTag("bull12")) // Eğer   etiketiyle çarparsa
        {
            TakeDamage(); // Hasar al
        }
        else if (other.CompareTag("bull13")) // Eğer   etiketiyle çarparsa
        {
            TakeDamage(); // Hasar al
        }


        else if (other.CompareTag("extra_life")) // Eğer "extra_life" etiketiyle çarparsa
        {
            extra_life(); // +1 can ekle
        }
    }

    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageAmount; // Hasar miktarını çıkar
            UpdateHearts();
        }
        else if (currentHealth == 0)
        {

            Debug.Log("Canınız kalmadı!");

            //  reklam gösterme 
            if (adManager != null)
            {
                adManager.OnCharacterDeath(); // Reklam göster  
            }


        }
    }

    public void extra_life()
    {
        if (currentHealth > 0)
        {
            currentHealth += extralife; // +1 life ekle
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
                if (i < currentHealth)
                {
                    heartImages[i].color = Color.white; // Dolu kalp için 
                }

                else if (i < 1)
                {
                    heartImages[i].color = Color.white; // Dolu kalp için 
                }
                else
                {
                    heartImages[i].color = new Color32(56, 56, 56, 255); // Boş kalp için 
                }

            }
            else
            {
                Debug.LogError($"Kalp Nesnesi {i} Image bileşenine sahip değil.");
            }
        }
    }
}

