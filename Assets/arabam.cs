using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class arabam : MonoBehaviour
{
    public Button arabamButton; // İlk buton referansı
    public Button otherButton; // Diğer buton referansı (ikinci buton)
    public float speedIncrease = 20f; // Hız artışı miktarı
    private UpDown player; // Player script referansı, hızı kontrol etmek için

    void Start()
    {
        arabamButton.gameObject.SetActive(false); // İlk butonu başta gizle
        otherButton.gameObject.SetActive(true);  // Diğer butonu göster

        StartCoroutine(ShowButtonPeriodically(60f, 5f)); // İlk butonu 60 saniyede bir 5 saniyeliğine göster

        // Player script referansını al
        player = FindObjectOfType<UpDown>();

        // İlk buton tıklama olayını bağla
        arabamButton.onClick.AddListener(OnArabamButtonClicked);

        // Diğer buton tıklama olayını bağla
        otherButton.onClick.AddListener(OnOtherButtonClicked);
    }

    // İlk butona tıklama olayı
    void OnArabamButtonClicked()
    {
        // İlk butonu gizle
        arabamButton.gameObject.SetActive(false);

        // Hız arttırma işlemi
        StartCoroutine(IncreaseSpeedTemporarily(3f)); // 5 saniye boyunca hızı arttır
    }

    // Diğer butona tıklama olayı
    void OnOtherButtonClicked()
    {
        // Diğer butonu gizle
        otherButton.gameObject.SetActive(false);

        // Aynı zamanda ilk butonu da gizle
        arabamButton.gameObject.SetActive(false);
    }

    // Butonu döngüsel olarak gösteren Coroutine
    IEnumerator ShowButtonPeriodically(float cycleTime, float activeTime)
    {
        while (true) // Sonsuz döngü
        {
            arabamButton.gameObject.SetActive(true); // İlk butonu aktif et
            yield return new WaitForSeconds(activeTime); // Butonun 5 saniye görünmesini sağla
            arabamButton.gameObject.SetActive(false); // İlk butonu gizle
            yield return new WaitForSeconds(cycleTime - activeTime); // 60 saniye döngüsünün geri kalanını bekle
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

        // 5 saniye bekle
        yield return new WaitForSeconds(duration);

        // Hızları eski haline döndür
        player.maxSpeed = originalMaxSpeed;
        player.moveSpeed = originalMoveSpeed;
    }
}
