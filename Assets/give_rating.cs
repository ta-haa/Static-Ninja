using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class give_rating : MonoBehaviour
{
    public void OnRateButtonClicked()
    {
#if UNITY_ANDROID
        // Google Play Store sayfasına yönlendirme
        string packageName = "com.taha.keskin"; // Oyununuzun paket adı (Play Store'daki uygulamanızın adı)
        Application.OpenURL("https://play.google.com/store/apps/details?id=" + packageName);
#endif
    }
}
