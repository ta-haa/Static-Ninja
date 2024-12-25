using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Skinsatinalma : MonoBehaviour
{
    // Oyuncunun sağlığı ve pozisyonu bilgilerini saklayacağız
    private Vector3 lastCheckpointPosition;
    private int lastCheckpointHealth;

    public Player player;  // Player scriptine referans (para için)
    public Skill skill1;  // Yeni açılacak beceriye referans
    public Skill skill2;  // Yeni açılacak beceriye referans
    public Skill skill3;  // Yeni açılacak beceriye referans
    public Skill skill4;  // Yeni açılacak beceriye referans
    public Skill skill5;  // Yeni açılacak beceriye referans
    public Skill skill6;  // Yeni açılacak beceriye referans 

    public Button buttonSkill1; // Skill 1 butonu
    public Button buttonSkill2; // Skill 2 butonu
    public Button buttonSkill3; // Skill 3 butonu
    public Button buttonSkill4; // Skill 4 butonu
    public Button buttonSkill5; // Skill 5 butonu
    public Button buttonSkill6; // Skill 6 butonu

    private void Start()
    {
        // Başlangıçta butonları kontrol et
        UpdateButtonState();
    }

    // Beceriler açıldıkça butonların durumunu günceller
    private void UpdateButtonState()
    {
        // Skill 1 için butonun durumu
        if (buttonSkill1 != null)
        {
            buttonSkill1.interactable = player != null && player.money >= 500 && skill1 != null && !skill1.isUnlocked;
        }

        // Skill 2 için butonun durumu
        if (buttonSkill2 != null)
        {
            buttonSkill2.interactable = player != null && player.money >= 500 && skill2 != null && !skill2.isUnlocked;
        }

        // Skill 3 için butonun durumu
        if (buttonSkill3 != null)
        {
            buttonSkill3.interactable = player != null && player.money >= 500 && skill3 != null && !skill3.isUnlocked;
        }

        // Skill 4 için butonun durumu
        if (buttonSkill4 != null)
        {
            buttonSkill4.interactable = player != null && player.money >= 500 && skill4 != null && !skill4.isUnlocked;
        }

        // Skill 5 için butonun durumu
        if (buttonSkill5 != null)
        {
            buttonSkill5.interactable = player != null && player.money >= 500 && skill5 != null && !skill5.isUnlocked;
        }

        // Skill 6 için butonun durumu
        if (buttonSkill6 != null)
        {
            buttonSkill6.interactable = player != null && player.money >= 500 && skill6 != null && !skill6.isUnlocked;
        }
    }

    // Skill açma fonksiyonları
    public void canvasskill1()
    {
        if (player != null && player.money >= 500 && skill1 != null && !skill1.isUnlocked)  // Para ve skill kontrolü
        {
            skill1.UnlockSkill();
            Debug.Log("Skill açıldı: Lazer");
            int rewardAmount = -500;
            player.AddMoney(rewardAmount);

            // Buton durumunu güncelle
            UpdateButtonState();
        }
        else
        {
            Debug.Log("Yeterli paranız yok veya skill zaten açık!");
        }
    }

    public void canvasskill2()
    {
        if (player != null && player.money >= 500 && skill2 != null && !skill2.isUnlocked)
        {
            skill2.UnlockSkill();
            Debug.Log("Skill açıldı: Lazer");
            int rewardAmount = -500;
            player.AddMoney(rewardAmount);
            UpdateButtonState();
        }
        else
        {
            Debug.Log("Yeterli paranız yok veya skill zaten açık!");
        }
    }

    public void canvasskill3()
    {
        if (player != null && player.money >= 500 && skill3 != null && !skill3.isUnlocked)
        {
            skill3.UnlockSkill();
            Debug.Log("Skill açıldı: Lazer");
            int rewardAmount = -500;
            player.AddMoney(rewardAmount);
            UpdateButtonState();
        }
        else
        {
            Debug.Log("Yeterli paranız yok veya skill zaten açık!");
        }
    }

    public void canvasskill4()
    {
        if (player != null && player.money >= 500 && skill4 != null && !skill4.isUnlocked)
        {
            skill4.UnlockSkill();
            Debug.Log("Skill açıldı: Lazer");
            int rewardAmount = -500;
            player.AddMoney(rewardAmount);
            UpdateButtonState();
        }
        else
        {
            Debug.Log("Yeterli paranız yok veya skill zaten açık!");
        }
    }

    public void canvasskill5()
    {
        if (player != null && player.money >= 500 && skill5 != null && !skill5.isUnlocked)
        {
            skill5.UnlockSkill();
            Debug.Log("Skill açıldı: Lazer");
            int rewardAmount = -500;
            player.AddMoney(rewardAmount);
            UpdateButtonState();
        }
        else
        {
            Debug.Log("Yeterli paranız yok veya skill zaten açık!");
        }
    }

    public void canvasskill6()
    {
        if (player != null && player.money >= 500 && skill6 != null && !skill6.isUnlocked)
        {
            skill6.UnlockSkill();
            Debug.Log("Skill açıldı: Lazer");
            int rewardAmount = -500;
            player.AddMoney(rewardAmount);
            UpdateButtonState();
        }
        else
        {
            Debug.Log("Yeterli paranız yok veya skill zaten açık!");
        }
    }



    // Yeniden başlatma butonuna basıldığında yapılacak işlemler
    public void canvasRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Ana menüye dönme
    public void canvasMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // GameOver'dan önce kaydedilen son pozisyon ve sağlık bilgilerini sakla
    public void SetCheckpoint(Vector3 position, int health)
    {
        lastCheckpointPosition = position;
        lastCheckpointHealth = health;
        PlayerPrefs.SetFloat("CheckpointPosX", position.x);
        PlayerPrefs.SetFloat("CheckpointPosY", position.y);
        PlayerPrefs.SetFloat("CheckpointPosZ", position.z);
        PlayerPrefs.SetInt("CheckpointHealth", health);
        PlayerPrefs.Save();
    }

    // GameOver ekranı açıldığında bu fonksiyon bilgileri PlayerPrefs'ten alıp set eder
    public void LoadCheckpoint()
    {
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
