using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro kullanmak için gerekli

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private int highScore = 0; // En yüksek skor
    private Vector3 lastPosition;
    public float moveThreshold = 100f; // Hareket eşiği
    public TextMeshProUGUI scoreText; // Puanı göstermek için UI bileşeni
    public TextMeshProUGUI highScoreText; // En yüksek skoru göstermek için UI bileşeni

    private const string ScoreKey = "PlayerScore"; // Puanı saklamak için anahtar
    private const string HighScoreKey = "HighScore"; // En yüksek skoru saklamak için anahtar

    void Start()
    {
        // Her oyun başladığında puanı sıfırla
        score = 0;

        // Kaydedilmiş yüksek skoru yükle (puan sıfırlanacak ama yüksek skor korunacak)
        highScore = PlayerPrefs.GetInt(HighScoreKey, 0); // Eğer kaydedilmiş bir yüksek skor yoksa, varsayılan olarak 0 alır

        lastPosition = transform.position;
        UpdateScoreText(); // Başlangıçta puanı ve yüksek skoru güncelle
    }


    void Update()
    {
        // Karakterin yeni pozisyonunu kontrol et
        if (Vector3.Distance(transform.position, lastPosition) > moveThreshold)
        {
            // Karakter hareket ettiğinde puanı artır
            score += 1;
            lastPosition = transform.position;

            // Yüksek skoru güncelle
            if (score > highScore)
            {
                highScore = score;
                // Yüksek skoru kaydet
                PlayerPrefs.SetInt(HighScoreKey, highScore);
                PlayerPrefs.Save(); // Kaydedilen veriyi diske yaz
            }

            // Puanı kaydet
            PlayerPrefs.SetInt(ScoreKey, score);
            PlayerPrefs.Save(); // Kaydedilen veriyi diske yaz

            // UI'yi güncelle
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        // Puanı ve en yüksek skoru ekrana yazdır
        scoreText.text = "S " + score;
        highScoreText.text = "HS " + highScore;
    }

    // Oyunun sonlanması veya başka bir durumda kaydedilen puanı sıfırlamak isterseniz:
    public void ResetScore()
    {
        score = 0;
        PlayerPrefs.SetInt(ScoreKey, score);
        PlayerPrefs.Save();
        UpdateScoreText();
    }
}
