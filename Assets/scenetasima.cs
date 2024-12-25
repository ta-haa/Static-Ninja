using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenetasima : MonoBehaviour
{
    // Karakterin prefab'ı
    public GameObject characterPrefab;

    // Static bir referans oluşturuyoruz
    public static GameObject staticCharacterPrefab;

    void Awake()
    {
        // Karakterin prefab'ını sahneye ekliyoruz
        if (characterPrefab != null)
        {
            Instantiate(characterPrefab);
            staticCharacterPrefab = characterPrefab; // Static referansa atama
        }

        // Karakteri sahneler arası taşımak için Don't Destroy On Load fonksiyonunu çağırıyoruz
        DontDestroyOnLoad(gameObject);
    }
}
