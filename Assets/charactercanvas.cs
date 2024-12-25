using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // Required to load new scenes

public class charactercanvas : MonoBehaviour
{
    public Button pauseButton;  // Buton referansı
    public Button resumeButton; // Resume buton referansı
    public Button btnskin1; // Skin button referansı
    public Button btnskin2; // Skin button referansı
    public Button btnskin3; // Skin button referansı
    public Button btnskin4; // Skin button referansı
    public Button btnskin5; // Skin button referansı
    public Button btnskin6; // Skin button referansı
    public Button btnCharacterMenu; // Character Menu button

    public Image pauseImage;    // Oyun durduğunda görünmesini istediğimiz Image

    public Image imgskin1;    // Oyun durduğunda görünmesini istediğimiz Image
    public Image imgskin2;    // Oyun durduğunda görünmesini istediğimiz Image
    public Image imgskin3;    // Oyun durduğunda görünmesini istediğimiz Image
    public Image imgskin4;    // Oyun durduğunda görünmesini istediğimiz Image
    public Image imgskin5;    // Oyun durduğunda görünmesini istediğimiz Image
    public Image imgskin6;    // Oyun durduğunda görünmesini istediğimiz Image

    public Image imgskill1;    // Oyun durduğunda görünmesini istediğimiz Image
    public Image imgskill2;    // Oyun durduğunda görünmesini istediğimiz Image
    public Button btnskill1;    // Oyun durduğunda görünmesini istediğimiz Image
    public Button btnskill2;    // Oyun durduğunda görünmesini istediğimiz Image 

    public Image imgskinvarsayilan;    // Oyun durduğunda görünmesini istediğimiz Image
    public Button btnskinvarsayilan;    // Oyun durduğunda görünmesini istediğimiz Image

    public Button star; // Reference to the Skill script

    public Button qr;    // Oyun durduğunda görünmesini istediğimiz Image 

    void Start()
    {
        // Butonlara tıklama olaylarını bağla
        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
        btnCharacterMenu.onClick.AddListener(GoToCharacterMenu);

        // Başlangıçta Image'i ve Resume butonunu gizle
        pauseImage.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);

        btnskin1.gameObject.SetActive(false);
        btnskin2.gameObject.SetActive(false);
        btnskin3.gameObject.SetActive(false);
        btnskin4.gameObject.SetActive(false);
        btnskin5.gameObject.SetActive(false);
        btnskin6.gameObject.SetActive(false);

        imgskin1.gameObject.SetActive(false);
        imgskin2.gameObject.SetActive(false);
        imgskin3.gameObject.SetActive(false);
        imgskin4.gameObject.SetActive(false);
        imgskin5.gameObject.SetActive(false);
        imgskin6.gameObject.SetActive(false);

        btnskill1.gameObject.SetActive(false);
        btnskill2.gameObject.SetActive(false);
        imgskill1.gameObject.SetActive(false);
        imgskill2.gameObject.SetActive(false);

        imgskinvarsayilan.gameObject.SetActive(false);
        btnskinvarsayilan.gameObject.SetActive(false);

        star.gameObject.SetActive(false);

        qr.gameObject.SetActive(false);



    }

    void Pause()
    {
        // Zamanı durdur
        Time.timeScale = 0f;

        // Oyun durduğunda Image'i göster
        pauseImage.gameObject.SetActive(true);

        // Resume butonunu görünür yap
        resumeButton.gameObject.SetActive(true);

        btnskin1.gameObject.SetActive(true);
        btnskin2.gameObject.SetActive(true);
        btnskin3.gameObject.SetActive(true);
        btnskin4.gameObject.SetActive(true);
        btnskin5.gameObject.SetActive(true);
        btnskin6.gameObject.SetActive(true);

        imgskin1.gameObject.SetActive(true);
        imgskin2.gameObject.SetActive(true);
        imgskin3.gameObject.SetActive(true);
        imgskin4.gameObject.SetActive(true);
        imgskin5.gameObject.SetActive(true);
        imgskin6.gameObject.SetActive(true);

        btnskill1.gameObject.SetActive(true);
        btnskill2.gameObject.SetActive(true);
        imgskill1.gameObject.SetActive(true);
        imgskill2.gameObject.SetActive(true);

        imgskinvarsayilan.gameObject.SetActive(true);
        btnskinvarsayilan.gameObject.SetActive(true);

        star.gameObject.SetActive(true);

        qr.gameObject.SetActive(true);

    }

    void Resume()
    {
        // Zamanı normal hızda çalışacak şekilde ayarla
        Time.timeScale = 1f;

        // Oyun tekrar başladığında Image'i ve Resume butonunu gizle
        pauseImage.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);

        btnskin1.gameObject.SetActive(false);
        btnskin2.gameObject.SetActive(false);
        btnskin3.gameObject.SetActive(false);
        btnskin4.gameObject.SetActive(false);
        btnskin5.gameObject.SetActive(false);
        btnskin6.gameObject.SetActive(false);

        imgskin1.gameObject.SetActive(false);
        imgskin2.gameObject.SetActive(false);
        imgskin3.gameObject.SetActive(false);
        imgskin4.gameObject.SetActive(false);
        imgskin5.gameObject.SetActive(false);
        imgskin6.gameObject.SetActive(false);

        btnskill1.gameObject.SetActive(false);
        btnskill2.gameObject.SetActive(false);
        imgskill1.gameObject.SetActive(false);
        imgskill2.gameObject.SetActive(false);

        imgskinvarsayilan.gameObject.SetActive(false);
        btnskinvarsayilan.gameObject.SetActive(false);

        star.gameObject.SetActive(false);

        qr.gameObject.SetActive(false);

    }


    void GoToCharacterMenu()
    {

        SceneManager.LoadScene("MainMenu");
        Resume();
    }
}
