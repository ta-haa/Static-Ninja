using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class player_music : MonoBehaviour
{
    public AudioSource audioSource;  // Müzik çalmak için AudioSource
    public AudioClip[] musicTracks; // Müzik dosyalarının olduğu dizi

    private void Start()
    {
        // Başlangıçta ilk müziği çal
        PlayRandomTrack();
    }

    private void Update()
    {
        // Eğer çalan müzik bittiğinde yeni müzik çalması gerekiyorsa
        if (!audioSource.isPlaying)
        {
            PlayRandomTrack();
        }
    }

    // Rastgele bir müzik çalma fonksiyonu
    private void PlayRandomTrack()
    {
        // Rastgele bir müzik seç
        int randomIndex = Random.Range(0, musicTracks.Length);
        AudioClip selectedTrack = musicTracks[randomIndex];

        // Seçilen müziği çal
        audioSource.clip = selectedTrack;
        audioSource.Play();
    }
}

