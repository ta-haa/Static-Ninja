using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landscape : MonoBehaviour
{
    void Update()
    {
        // Cihazın yönünü kontrol et
        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
        {
            // Ekranı sol yatay konumuna döndür
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            // Ekranı sağ yatay konumuna döndür
            Screen.orientation = ScreenOrientation.LandscapeRight;
        }
    }
}
