using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Reference to the AudioSource component
    public AudioSource audioSource;

    // Reference to the AudioClip (music or sound effect)
    public AudioClip buttonClickSound;

    // Function to play the music or sound effect when a button is clicked
    private void PlayButtonClickSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }

    public void PlayGame()
    {
        PlayButtonClickSound();  // Play the sound when the button is clicked
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Settings()
    {
        PlayButtonClickSound();  // Play the sound when the button is clicked
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void Credits()
    {
        PlayButtonClickSound();  // Play the sound when the button is clicked
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    public void QuitGame()
    {
        PlayButtonClickSound();  // Play the sound when the button is clicked
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        PlayButtonClickSound();  // Play the sound when the button is clicked
        SceneManager.LoadScene("MainMenu");
    }
}
