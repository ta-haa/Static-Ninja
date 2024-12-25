using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class responsive : MonoBehaviour
{
    // Referans çözünürlüğü (oyunun tasarlandığı ideal çözünürlük)
    public Vector2 referenceResolution = new Vector2(1920, 1080);

    // Başlangıç ölçeği
    private Vector3 initialScale;

    void Start()
    {
        // Başlangıçta tüm nesnenin orijinal ölçeğini kaydedelim
        initialScale = transform.localScale;
    }

    void Update()
    {
        // Ekran çözünürlüğünü alalım
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Ekran boyutlarının orijinal çözünürlük ile karşılaştırılması
        float scaleFactorWidth = screenWidth / referenceResolution.x;
        float scaleFactorHeight = screenHeight / referenceResolution.y;

        // Her iki faktörü de göz önünde bulundurarak en uygun ölçek faktörünü hesaplayalım
        float scaleFactor = Mathf.Max(scaleFactorWidth, scaleFactorHeight);

        // Nesnenin ölçeğini yeni faktöre göre ayarlayalım
        transform.localScale = initialScale * scaleFactor;
    }
}
