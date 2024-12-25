using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class qr_code : MonoBehaviour
{
    public void OnRateButtonClicked()
    {
#if UNITY_ANDROID 
        Application.OpenURL("https://www.youtube.com/@TahaKeskin");
#endif
    }
}