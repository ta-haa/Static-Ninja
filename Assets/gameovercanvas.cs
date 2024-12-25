using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameovercanvas : MonoBehaviour
{


    // Oyuncunun sağlığı ve pozisyonu bilgilerini saklayacağız
    private Vector3 lastCheckpointPosition;
    private int lastCheckpointHealth;

    public Player player;  // Player scriptine referans (para  k için)
    public Skill skillsimsek;  // Yeni açılacak beceriye referans
    public Skill skilllaser;  // Yeni açılacak beceriye referans
    public void canvaslaser()
    {
        // Para kontrolü yapıyoruz
        if (player != null && player.money >= 1000)  // 1000 para gerekiyorsa
        {
            if (skilllaser != null)
            {
                skilllaser.UnlockSkill();  // Beceriyi açıyoruz
                Debug.Log("Skil açıldı lazer");

                // Parayı düşüyoruz
                int rewardAmount = -1000;
                player.AddMoney(rewardAmount);  // Para işlemi 
            }
        }
        else
        {
            Debug.Log("Yeterli paranız yok!");
        }
    }

    public void canvassimsek()
    {
        // Para kontrolü yapıyoruz
        if (player != null && player.money >= 1000)  // 1000 para gerekiyorsa
        {
            if (skillsimsek != null)
            {
                skillsimsek.UnlockSkill();  // Beceriyi açıyoruz
                Debug.Log("Skil açıldı simsek");

                // Parayı düşüyoruz
                int rewardAmount = -1000;
                player.AddMoney(rewardAmount);  // Para işlemi 
            }
        }
        else
        {
            Debug.Log("Yeterli paranız yok!");
        }
    }
    // Yeniden başlatma butonuna basıldığında yapılacak işlemler
    public void canvasRestart()
    {
        // Mevcut sahnede yeniden başlat
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Ana menüye dönme
    public void canvasMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Ana menü sahnesine dön
    }

    // GameOver'dan önce kaydedilen son pozisyon ve sağlık bilgilerini sakla
    public void SetCheckpoint(Vector3 position, int health)
    {
        lastCheckpointPosition = position;
        lastCheckpointHealth = health;

        // Bilgileri PlayerPrefs'e kaydediyoruz
        PlayerPrefs.SetFloat("CheckpointPosX", position.x);
        PlayerPrefs.SetFloat("CheckpointPosY", position.y);
        PlayerPrefs.SetFloat("CheckpointPosZ", position.z);
        PlayerPrefs.SetInt("CheckpointHealth", health);
        PlayerPrefs.Save();
    }

    // GameOver ekranı açıldığında bu fonksiyon bilgileri PlayerPrefs'ten alıp set eder
    public void LoadCheckpoint()
    {
        // Kaydedilen veriler varsa, pozisyonu ve sağlığı geri yükle
        if (PlayerPrefs.HasKey("CheckpointPosX"))
        {
            float posX = PlayerPrefs.GetFloat("CheckpointPosX");
            float posY = PlayerPrefs.GetFloat("CheckpointPosY");
            float posZ = PlayerPrefs.GetFloat("CheckpointPosZ");
            lastCheckpointPosition = new Vector3(posX, posY, posZ);
            lastCheckpointHealth = PlayerPrefs.GetInt("CheckpointHealth");
        }
    }
}
