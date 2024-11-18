using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;
public class creditsclick : MonoBehaviour
{
    void Update()
    {
        // Mobil cihazlarda ekrana dokunulduğunda ana menüye dön
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            // Ana sayfaya dönmek için
            SceneManager.LoadScene("MainMenu");
        }
    }


}
