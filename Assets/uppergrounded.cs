using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uppergrounded : MonoBehaviour
{
    public GameObject upperplatformPrefab; // Platform prefab'ı
    public float upperspawnRate = 0.5f; // Platformların ne sıklıkla doğacağı
    private float uppertimer = 0f; // Zamanlayıcı
    private float upperlastPlatformPositionX = 0f; // Son platformun X pozisyonu

    void Start()
    {
        // Başlangıçta birkaç platform oluşturun
        for (int i = 0; i < 55; i++)
        {
            upperSpawnPlatform();
        }
    }

    void Update()
    {
        uppertimer += Time.deltaTime;
        if (uppertimer >= upperspawnRate)
        {
            upperSpawnPlatform();
            uppertimer = 0f;
        }
    }

    void upperSpawnPlatform()
    {
        // Yeni platform oluşturulacak
        float platformWidth = 1f; // Platformun genişliği
        upperlastPlatformPositionX += platformWidth; // Yeni platformun X pozisyonunu güncelle
        float gap = 30f; // Platformlar arasındaki boşluk
        upperlastPlatformPositionX += platformWidth + gap; // Yeni platformun X pozisyonunu güncelle


        // Yeni platformu oluştur
        Instantiate(upperplatformPrefab, new Vector3(upperlastPlatformPositionX, 15f, 0), Quaternion.identity);
    }
}
