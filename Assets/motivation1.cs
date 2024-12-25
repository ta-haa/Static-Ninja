using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class motivation1 : MonoBehaviour
{
    public TextMeshProUGUI displayText;

    private void Start()
    {
        // Başlangıçta metni gizli yapıyoruz
        displayText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Eğer tetiklemeyi yapan nesne belirli bir tag'e sahipse
        if (other.CompareTag("Player"))
        {
            // Metni ekranda göster
            displayText.gameObject.SetActive(true);
            //displayText.text = "Good luck to you !";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Player alanı terk ederse metni gizle
        if (other.CompareTag("Player"))
        {
            displayText.gameObject.SetActive(false);
        }
    }
}

