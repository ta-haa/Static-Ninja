using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireee : MonoBehaviour
{
    public GameObject[] firePrefabs; // Ateş prefab'ları dizisi
    public Transform[] fireSpawnPoints; // Ateşin fırlatılacağı spawn noktaları dizisi
    public float minFireInterval = 0.5f;      // Minimum ateş etme süresi
    public float maxFireInterval = 1f;      // Maksimum ateş etme süresi
    public float fireSpeed = 20f; // Ateş topunun hızı
    public float fireLifetime = 5f; // Ateş topunun yaşam süresi (saniye)

    private void Start()
    {
        // Başlangıçta ateş etmeye başla
        StartCoroutine(FireBallsRoutine());
    }

    private IEnumerator FireBallsRoutine()
    {
        // Sonsuz döngüyle ateş topları atacağız
        while (true)
        {
            // Rastgele bir süreyle ateş et
            float fireInterval = Random.Range(minFireInterval, maxFireInterval);
            yield return new WaitForSeconds(fireInterval);

            // Rastgele bir fire prefab'ı ve spawn point seç
            int randomFireIndex = Random.Range(0, firePrefabs.Length);
            int randomSpawnIndex = Random.Range(0, fireSpawnPoints.Length);

            // Ateş topu oluştur ve aşağıya doğru fırlat
            ThrowFire(firePrefabs[randomFireIndex], fireSpawnPoints[randomSpawnIndex], Vector2.down); // Aşağıya doğru ateş et
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

    public void ThrowFire(GameObject firePrefab, Transform fireSpawnPoint, Vector2 direction)
    {
        // Ateş prefab'ından yeni bir örnek oluştur
        GameObject fire = Instantiate(firePrefab, fireSpawnPoint.position, Quaternion.identity);

        // Ateşin Rigidbody2D bileşenini al
        Rigidbody2D fireRb = fire.GetComponent<Rigidbody2D>();

        // Ateşi fırlatmak için kuvvet uygula
        fireRb.velocity = direction * fireSpeed; // Verilen yönde fırlat

        // 5 saniye sonra ateşi yok et
        Destroy(fire, fireLifetime);
    }
}
