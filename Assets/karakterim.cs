using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class karakterim : MonoBehaviour
{
    public Button karaktermButton; // İlk buton referansı
    public Button otherButton; // Diğer buton referansı (ikinci buton)
    public float speedIncrease = 10f; // Hız artışı miktarı
    private UpDown player; // Player script referansı, hızı kontrol etmek için

    void Start()
    {
        // Butonların başlangıç durumları
        otherButton.gameObject.SetActive(true);  // Diğer butonu göster
        karaktermButton.gameObject.SetActive(false); // İlk butonu başta gizle

        // İlk butonu 10 saniyede bir 5 saniyeliğine göster
        StartCoroutine(ShowButtonPeriodically(30f, 5f));

        // Player script referansını al
        player = FindObjectOfType<UpDown>();

        // Buton tıklama olaylarını bağla
        karaktermButton.onClick.AddListener(OnkaraktermButtonClicked);
        otherButton.onClick.AddListener(OnOtherButtonClicked);
    }

    // İlk butona tıklama olayı
    void OnkaraktermButtonClicked()
    {
        // İlk butonu gizle
        karaktermButton.gameObject.SetActive(false);

        // Hız arttırma işlemi
        StartCoroutine(IncreaseSpeedTemporarily(5f)); // 3 saniye boyunca hızı arttır
    }

    // Diğer butona tıklama olayı
    void OnOtherButtonClicked()
    {
        // Diğer butonu gizle
        otherButton.gameObject.SetActive(false);

        // Aynı zamanda ilk butonu da gizle
        karaktermButton.gameObject.SetActive(false);
    }

    // Butonu döngüsel olarak gösteren Coroutine
    IEnumerator ShowButtonPeriodically(float cycleTime, float activeTime)
    {
        while (true) // Sonsuz döngü
        {
            karaktermButton.gameObject.SetActive(true); // İlk butonu aktif et
            yield return new WaitForSeconds(activeTime); // Butonun 5 saniye görünmesini sağla
            karaktermButton.gameObject.SetActive(false); // İlk butonu gizle
            yield return new WaitForSeconds(cycleTime - activeTime); // Döngü süresi kadar bekle
        }
    }

    // Hız artışını geçici olarak sağlamak için Coroutine
    IEnumerator IncreaseSpeedTemporarily(float duration)
    {
        // Eski hızları kaydet
        float originalMaxSpeed = player.maxSpeed;
        float originalMoveSpeed = player.moveSpeed;

        // Hızı arttır
        player.maxSpeed += speedIncrease;
        player.moveSpeed += speedIncrease;

        // Belirtilen süre boyunca bekle (3 saniye)
        yield return new WaitForSeconds(duration);

        // Hızları eski haline döndür
        player.maxSpeed = originalMaxSpeed;
        player.moveSpeed = originalMoveSpeed;
    }
}
