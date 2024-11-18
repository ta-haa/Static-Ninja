using UnityEngine;
using UnityEngine.UI;

public class sound_settings : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1);
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume); // Ses seviyesini kaydet
        PlayerPrefs.Save(); // Değişiklikleri hemen kaydet
    }
}
