using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // SceneManager sınıfını kullanabilmek için

public class intro_scene_transition : MonoBehaviour
{
    public float delayTime = 6f; // Geçiş için bekleme süresi
    public float fadeDuration = 3f; // Ekranın her saniyede biraz kararması için süre
    private Camera mainCamera; // Ana kamera

    // Start is called before the first frame update
    void Start()
    {
        // Ana kamerayı al
        mainCamera = Camera.main;

        // Eğer ana kamera yoksa, hata mesajı ver
        if (mainCamera == null)
        {
            Debug.LogError("Ana kamera bulunamadı!");
            return;
        }

        // Başlangıç rengini RGB(0, 55, 31) olarak ayarla
        mainCamera.backgroundColor = new Color(0f / 255f, 55f / 255f, 31f / 255f);

        // Ekranı yavaşça karartmaya başla
        StartCoroutine(FadeToBlack());

        // 7.5 saniye sonra 'LoadMainMenu' fonksiyonunu çağırır
        StartCoroutine(LoadMainMenuAfterDelay());
    }

    // Bu IEnumerator, sahne geçişini geciktirir
    IEnumerator LoadMainMenuAfterDelay()
    {
        // Geçişi delayTime kadar bekle
        yield return new WaitForSeconds(delayTime);

        // MainMenu sahnesine geçiş yap
        SceneManager.LoadScene("MainMenu");
    }

    // Ekranı yavaşça karartmak için bir fonksiyon
    IEnumerator FadeToBlack()
    {
        float elapsedTime = 0f;
        Color initialColor = mainCamera.backgroundColor;

        // Ekranı siyah yapana kadar alfa değerini arttır
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;

            // Geçişi, geçen süre ile orantılı yap
            float lerpFactor = Mathf.Clamp01(elapsedTime / fadeDuration);
            mainCamera.backgroundColor = Color.Lerp(initialColor, Color.black, lerpFactor);

            yield return null; // Bir frame bekle
        }

        // Arka plan rengini tamamen siyah yap
        mainCamera.backgroundColor = Color.black;
    }
}
