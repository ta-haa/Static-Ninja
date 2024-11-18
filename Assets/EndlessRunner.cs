using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRunner : MonoBehaviour
{
    public GameObject platformPrefab; // Platform prefab'ı
    public float spawnRate = 0.5f; // Platformların ne sıklıkla doğacağı
    private float timer = 0f; // Zamanlayıcı
    private float lastPlatformPositionX = 0f; // Son platformun X pozisyonu

    void Start()
    {
        // Başlangıçta birkaç platform oluşturun
        for (int i = 0; i < 55; i++)
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
        float platformWidth = 1f; // Platformun genişliği
        lastPlatformPositionX += platformWidth; // Yeni platformun X pozisyonunu güncelle
        float gap = 48f; // Platformlar arasındaki boşluk
        lastPlatformPositionX += platformWidth + gap; // Yeni platformun X pozisyonunu güncelle


        // Yeni platformu oluştur
        Instantiate(platformPrefab, new Vector3(lastPlatformPositionX, -5f, 0), Quaternion.identity);
    }
}
