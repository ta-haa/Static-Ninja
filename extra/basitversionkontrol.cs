using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // TextMeshPro kütüphanesini ekliyoruz
using UnityEngine.UI;

public class basitversionkontrol : MonoBehaviour
{

    // UI öğeleri
    public TMP_Text updateMessageText;  // Güncelleme mesajı için TextMeshProUGUI
    public Button updateButton;         // Güncelleme için Button

    // Sabit sürüm numarası
    private string latestVersion = "30";  // Burada son sürümü sabitliyorsunuz
    private string currentVersion;        // Oyun sürümünü alacağız

    void Start()
    {
        // Oyun sürümünü al
        currentVersion = Application.version;

        // Sürüm karşılaştırmasını yap
        if (CompareVersions(currentVersion, latestVersion) < 0)
        {
            // Eğer mevcut sürüm eskiyse, kullanıcıya güncelleme mesajı göster
            ShowUpdateAlert();
        }
        else
        {
            // Eğer sürüm güncelse, butonu gizle
            HideUpdateButton();
        }
    }

    // Sürüm karşılaştırması
    int CompareVersions(string version1, string version2)
    {
        var v1 = version1.Split('.');
        var v2 = version2.Split('.');
        for (int i = 0; i < v1.Length; i++)
        {
            int val1 = int.Parse(v1[i]);
            int val2 = int.Parse(v2[i]);
            if (val1 < val2) return -1; // Eğer version1 küçükse, eski sürüm
            if (val1 > val2) return 1;  // Eğer version1 büyükse, yeni sürüm
        }
        return 0; // Aynı sürüm
    }

    // Güncelleme mesajını ve butonu göster
    void ShowUpdateAlert()
    {
        updateMessageText.text = "New version. Please Update.";
        updateButton.gameObject.SetActive(true);  // Güncelleme butonunu aktif et
        updateButton.onClick.AddListener(() => OpenUpdatePage());
    }

    // Butonu gizle
    void HideUpdateButton()
    {
        updateButton.gameObject.SetActive(false);  // Güncelleme butonunu gizle
    }

    // Kullanıcıyı Play Store'a yönlendiren fonksiyon
    void OpenUpdatePage()
    {
        string packageName = "com.taha.keskin";  // Kendi uygulama ID'nizi buraya yazın
        string updateUrl = "https://play.google.com/store/apps/details?id=" + packageName;
        Application.OpenURL(updateUrl);  // Kullanıcıyı Play Store'a yönlendir
    }

}
