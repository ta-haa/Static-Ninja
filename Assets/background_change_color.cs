using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_change_color : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Color[] colors = {
        new Color(1f, 0f, 0f, 120f / 255f),                // Kırmızı
        Color.white,                                       // Beyaz
        new Color(0f, 1f, 190f / 255f, 120f / 255f),       // Açık Mavi
        new Color(0f, 1f, 141f / 255f, 120f / 255f),       // Yeşil Mavi
        Color.red,                                         // Kırmızı (yine)
        
        // Yeni renkler:
        new Color(1f, 0.5f, 0f, 120f / 255f),              // Turuncu
        new Color(0f, 0f, 1f, 120f / 255f),                // Mavi
        new Color(0.5f, 0f, 0.5f, 120f / 255f),            // Mor
        new Color(0.8f, 0.8f, 0f, 120f / 255f),            // Sarı
        new Color(0f, 0.5f, 0f, 120f / 255f),              // Koyu Yeşil
        new Color(0.5f, 0.5f, 0.5f, 120f / 255f),          // Gri
        new Color(1f, 0f, 1f, 120f / 255f),                // Pembe
        new Color(0.8f, 0.2f, 0.1f, 120f / 255f),          // Koyu Turuncu
        new Color(0.2f, 0.2f, 0.8f, 120f / 255f),          // Açık Mavi (daha soluk)
        new Color(0.9f, 0.9f, 0.9f, 120f / 255f)           // Açık Gri
    };

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        while (true)
        {
            // Rastgele bir renk seçiyoruz
            int randomColorIndex = Random.Range(0, colors.Length);
            spriteRenderer.color = colors[randomColorIndex];

            // 10 saniye bekle
            yield return new WaitForSeconds(10f);
        }
    }
}
