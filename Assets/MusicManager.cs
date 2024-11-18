using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // Eğer Play On Awake işaretli değilse, müziği burada başlatabilirsin
        audioSource.Play();
    }

    // Müzik durdurma
    public void StopMusic()
    {
        audioSource.Stop();
    }

    // Müzik başlatma
    public void PlayMusic()
    {
        audioSource.Play();
    }

    // Ses seviyesini değiştirme
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;  // 0 ile 1 arasında bir değer olmalı
    }
}

