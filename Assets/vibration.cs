using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vibration : MonoBehaviour
{
    public Toggle vibrationToggle;  // UI'da olan Toggle UI element'i

    void Start()
    {
        // Başlangıçta vibrasyon durumunu PlayerPrefs'ten oku
        bool isVibrationOn = IsVibrationEnabled();
        vibrationToggle.isOn = isVibrationOn;
    }

    public void ToggleVibration(bool isOn)
    {
        // Vibration durumunu kaydet
        SetVibrationEnabled(isOn);

        // Vibration'ı uygula
        ApplyVibration(isOn);
    }

    private void ApplyVibration(bool isOn)
    {
        if (isOn)
        {
            // Cihaz titreşimi aktif et
            Handheld.Vibrate();
        }
        else
        {
            // Eğer titreşim kapalı ise, herhangi bir şey yapılmaz.
            // Ancak başka platformlarda titreşimi kapatmak için başka çözümler kullanılabilir.
            Debug.Log("Vibration is turned off.");
        }
    }

    // PlayerPrefs üzerinden titreşim durumunu okuma
    private bool IsVibrationEnabled()
    {
        return PlayerPrefs.GetInt("VibrationEnabled", 1) == 1;
    }

    // PlayerPrefs üzerinden titreşim durumunu kaydetme
    private void SetVibrationEnabled(bool isEnabled)
    {
        PlayerPrefs.SetInt("VibrationEnabled", isEnabled ? 1 : 0);
        PlayerPrefs.Save(); // Değişiklikleri kaydet
    }
}
