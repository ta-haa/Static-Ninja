using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakterial : MonoBehaviour
{
    void Start()
    {
        if (scenetasima.staticCharacterPrefab != null)
        {
            // Karakter prefab'ını sahneye instantiate et
            Instantiate(scenetasima.staticCharacterPrefab);
        }
    }
}
