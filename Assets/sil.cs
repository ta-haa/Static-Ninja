using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sil : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();  // Tüm PlayerPrefs verilerini siler
        PlayerPrefs.Save();       // Değişiklikleri kaydet
    }

    // Update is called once per frame
    void Update()
    {

    }
}
