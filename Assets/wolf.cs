using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolf : MonoBehaviour
{
    public GameObject[] wolfPrefabs; // Ateş prefab'ları dizisi
    public Transform[] wolfSpawnPoints; // Ateşin fırlatılacağı spawn noktaları dizisi
    public float minwolfInterval = 0.5f;      // Minimum ateş etme süresi
    public float maxwolfInterval = 1f;      // Maksimum ateş etme süresi
    public float wolfSpeed = 20f; // Ateş topunun hızı
    public float wolfLifetime = 5f; // Ateş topunun yaşam süresi (saniye)

    private void Start()
    {
        // Başlangıçta ateş etmeye başla
        StartCoroutine(wolfBallsRoutine());
    }

    private IEnumerator wolfBallsRoutine()
    {
        // Sonsuz döngüyle ateş topları atacağız
        while (true)
        {
            // Rastgele bir süreyle ateş et
            float wolfInterval = Random.Range(minwolfInterval, maxwolfInterval);
            yield return new WaitForSeconds(wolfInterval);

            // Rastgele bir wolf prefab'ı ve spawn point seç
            int randomwolfIndex = Random.Range(0, wolfPrefabs.Length);
            int randomSpawnIndex = Random.Range(0, wolfSpawnPoints.Length);

            // Ateş topu oluştur ve aşağıya doğru fırlat
            Throwwolf(wolfPrefabs[randomwolfIndex], wolfSpawnPoints[randomSpawnIndex], Vector2.right); // Aşağıya doğru ateş et
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bull1") || collision.gameObject.CompareTag("bull2") || collision.gameObject.CompareTag("enemies1"))
        {
            Destroy(collision.gameObject);
        }
        // Çarpıştığı nesneyi yok et
    }

    public void Throwwolf(GameObject wolfPrefab, Transform wolfSpawnPoint, Vector2 direction)
    {
        // Ateş prefab'ından yeni bir örnek oluştur
        GameObject wolf = Instantiate(wolfPrefab, wolfSpawnPoint.position, Quaternion.identity);

        // Ateşin Rigidbody2D bileşenini al
        Rigidbody2D wolfRb = wolf.GetComponent<Rigidbody2D>();

        // Ateşi fırlatmak için kuvvet uygula
        wolfRb.velocity = direction * wolfSpeed; // Verilen yönde fırlat

        // 5 saniye sonra ateşi yok et
        Destroy(wolf, wolfLifetime);
    }
}
