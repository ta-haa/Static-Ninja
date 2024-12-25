using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScaleCode : MonoBehaviour
{
    // Slider, Button'lar, Toggle, Dropdown ve TextMeshPro referansları
    public Slider scaleSlider;  // Slider referansı
    public Button[] buttons;    // 5 adet Button referansı
    public TextMeshProUGUI[] textMeshPros;  // 5 adet TextMeshPro referansı
    public Toggle toggle;  // Toggle referansı
    public Slider otherSlider;  // Diğer slider referansı
    public Dropdown dropdown;  // Dropdown referansı

    private const string SCALE_KEY = "ScaleValue";  // PlayerPrefs anahtarı

    // Singleton pattern
    private static ScaleCode instance = null;

    void Awake()
    {
        // Eğer bir instance zaten varsa, bu objeyi yok et
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // Eğer yoksa, instance'ı ayarla ve sahneler arası taşınabilir yapmak için Don'tDestroyOnLoad kullan
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Slider'ın değerini PlayerPrefs'ten yükle
        float savedScale = PlayerPrefs.GetFloat(SCALE_KEY, 1f);  // Varsayılan olarak 1.0f
        scaleSlider.value = savedScale;  // Slider'ı kaydedilen değere ayarla

        // Başlangıçta butonların, metinlerin, toggle'ın, diğer slider'ın ve dropdown'un scale'ini ayarla
        SetScale(savedScale);

        // Slider değeri değiştiğinde tetiklenecek event
        scaleSlider.onValueChanged.AddListener(OnSliderValueChanged);

        // Slider'ın minimum ve maksimum değerlerini ayarla
        scaleSlider.minValue = 1f;  // Minimum değer 1.0
        scaleSlider.maxValue = 3f;  // Maksimum değer 3.0 (yani en büyük scale)
    }

    void OnSliderValueChanged(float value)
    {
        // Slider değeri değiştiğinde butonların, metinlerin, toggle'ın, diğer slider'ın ve dropdown'un scale'ini güncelle
        SetScale(value);

        // Kullanıcı scale değerini kaydet
        PlayerPrefs.SetFloat(SCALE_KEY, value);
        PlayerPrefs.Save();  // Kaydetmeyi unutma
    }

    // Butonların, TextMeshPro'ların, Toggle, Diğer Slider ve Dropdown'ın scale'ini ayarlayan fonksiyon
    void SetScale(float scale)
    {
        // Butonların scale'ini ayarla
        foreach (Button button in buttons)
        {
            button.transform.localScale = new Vector3(scale, scale, scale);
        }

        // TextMeshPro'ların scale'ini ayarla
        foreach (TextMeshProUGUI text in textMeshPros)
        {
            text.transform.localScale = new Vector3(scale, scale, scale);
        }

        // Toggle'ın scale'ini ayarla
        if (toggle != null)
        {
            toggle.transform.localScale = new Vector3(scale, scale, scale);
        }

        // Diğer Slider'ın scale'ini ayarla
        if (otherSlider != null)
        {
            otherSlider.transform.localScale = new Vector3(scale, scale, scale);
        }

        // Dropdown'ın scale'ini ayarla
        if (dropdown != null)
        {
            dropdown.transform.localScale = new Vector3(scale, scale, scale);
        }

        // Slider'ın (scaleSlider) kendi scale'ini de ayarla
        if (scaleSlider != null)
        {
            scaleSlider.transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    // Statik property ile singleton örneğine erişim
    public static ScaleCode Instance
    {
        get
        {
            return instance;
        }
    }
}
