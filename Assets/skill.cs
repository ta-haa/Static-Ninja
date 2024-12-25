using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine;

using UnityEngine;

public class Skill : MonoBehaviour
{
    public string skillName; // Becerinin adı
    public string description; // Becerinin açıklaması
    public bool isUnlocked; // Beceri açıldı mı?

    // Beceriyi açma fonksiyonu
    public void UnlockSkill()
    {
        if (!isUnlocked)
        {
            isUnlocked = true; // Beceriyi açıyoruz
            Debug.Log(skillName + " becerisi açıldı!");

            // Beceriyi kaydetmek için PlayerPrefs kullanıyoruz
            PlayerPrefs.SetInt(skillName + "_Unlocked", 1); // 1, becerinin açıldığını gösterir
            PlayerPrefs.Save(); // Kaydediyoruz
        }
        else
        {
            Debug.Log(skillName + " becerisi zaten açık!");
        }
    }

    // Beceriyi yükleme fonksiyonu (oyun başladığında)
    public void LoadSkill()
    {
        if (PlayerPrefs.HasKey(skillName + "_Unlocked"))
        {
            // Eğer PlayerPrefs'te bu beceri ile ilgili bir bilgi varsa, bu bilgiyi al
            isUnlocked = PlayerPrefs.GetInt(skillName + "_Unlocked") == 1;
            Debug.Log(skillName + " becerisinin durumu: " + (isUnlocked ? "Açık" : "Kapalı"));
        }
    }
}



