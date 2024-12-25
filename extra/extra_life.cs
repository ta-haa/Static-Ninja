using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{

    public GameObject heartPrefab; // Spawn edilecek kalp prefab'ı
    public Transform[] heartPoints; // Kalp objelerinin spawn edileceği noktalar
    public int startHeartTime = 10; // Kalplerin spawn olmaya başlamadan önceki bekleme süresi
    public int heartTime = 5; // Kalplerin spawn aralığı (her ne kadar bir süre)

    void Start()
    {
        // Kalp spawn etme coroutine'ini başlatıyoruz
        StartCoroutine(SpawnHearts());
    }

    // Kalp spawn etme işlemini yapan coroutine
    IEnumerator SpawnHearts()
    {
        // Başlangıçta belirtilen süre kadar bekle
        yield return new WaitForSeconds(startHeartTime);

        // Sürekli olarak kalp spawn et
        while (true)
        {
            SpawnHeartAtRandomPoint();
            yield return new WaitForSeconds(heartTime); // Her heartTime kadar bir kalp spawn et
        }
    }

    // Kalp objesini rastgele bir noktada spawn etme metodu
    void SpawnHeartAtRandomPoint()
    {
        // heartPoints array'inden rastgele bir indeks seç
        int randomIndex = Random.Range(0, heartPoints.Length);

        // Seçilen noktada kalp objesini instantiate et (yeni bir obje oluştur)
        Instantiate(heartPrefab, heartPoints[randomIndex].position, Quaternion.identity);
    }

}
