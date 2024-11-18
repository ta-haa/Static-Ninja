using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessFlower : MonoBehaviour
{
    public GameObject[] platformPrefabs; // Platform prefab'ları dizisi
    public float spawnRate = 1f; // Platformların ne sıklıkla doğacağı
    private float timer = 0f; // Zamanlayıcı
    private float lastPlatformPositionX = 0f; // Son platformun X pozisyonu

    void Start()
    {
        // Başlangıçta birkaç platform oluşturun
        for (int i = 0; i < 5; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnPlatform();
            timer = 0f;
        }
    }

    void SpawnPlatform()
    {
        // Yeni platform oluşturulacak
        float platformWidth = 2f; // Platformun genişliği
        float gap = Random.Range(1f, 10f); // Platformlar arasındaki rastgele boşluk
        lastPlatformPositionX += platformWidth + gap; // Yeni platformun X pozisyonunu güncelle

        // Rastgele bir platform prefab'ı seç
        int randomIndex = Random.Range(0, platformPrefabs.Length);
        GameObject selectedPlatformPrefab = platformPrefabs[randomIndex];

        // Yeni platformu oluştur
        Instantiate(selectedPlatformPrefab, new Vector3(lastPlatformPositionX, -4f, 0), Quaternion.identity);
    }
}
