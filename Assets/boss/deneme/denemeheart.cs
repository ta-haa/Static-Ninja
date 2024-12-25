using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI öğeleri için
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class denemeheart : MonoBehaviour
{
    public int health = 3;  // Başlangıçta 3 can
    public Image[] hearts;  // Kalp ikonlarını göstereceğimiz UI elementleri
    public Sprite fullHeart; // Tam kalp sprite'ı
    public Sprite emptyHeart; // Boş kalp sprite'ı
    private reklam adManager;

    void Start()
    {
        // Reklam yöneticisini buluyoruz
        adManager = FindObjectOfType<reklam>(); // Eğer "reklam" script'i sahnede bir GameObject'e eklenmişse, onu bulur

        // Reklamı yükle
        if (adManager != null)
        {
            adManager.LoadInterstitialAd(); // Başlangıçta reklam yükle
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        // Kalp ikonlarını güncelle
        UpdateHearts();

        // Titreşimi kontrol et ve uygula
        if (IsVibrationEnabled())
        {
            Handheld.Vibrate(); // Eğer titreşim açıksa, cihaz titreşecek 
        }

        // Eğer sağlık sıfırsa, oyuncu öldü
        if (health <= 0)
        {
            // Reklam gösterme
            if (adManager != null)
            {
                adManager.OnCharacterDeath(); // Reklam göster
            }
        }
    }

    // Kalp ikonlarını güncelleme fonksiyonu
    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Eğer sağlık durumu, kalp ikonunun sırasını geçiyorsa tam kalp göster
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    // Çarpışma olduğunda hasar al
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bull2") || collision.gameObject.CompareTag("enemies1") || collision.gameObject.CompareTag("bull1"))
        {
            TakeDamage(1); // Düşmana çarptığında 1 can kaybeder
        }
    }

    // PlayerPrefs üzerinden titreşim durumunu kontrol etme
    private bool IsVibrationEnabled()
    {
        return PlayerPrefs.GetInt("VibrationEnabled", 1) == 1;
    }
}
