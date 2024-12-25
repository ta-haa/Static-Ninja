using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int money = 0;  // Başlangıç para miktarı
    public TextMeshProUGUI moneyText; // TextMeshPro bileşeni için referans
    private const string paraKey = "para"; // Para değeri için anahtar

    private void Start()
    {
        // Uygulama başladığında, kaydedilmiş parayı yükle
        money = PlayerPrefs.GetInt(paraKey, 0);  // Eğer kaydedilmiş değer yoksa 0 kullanılır
        UpdateMoneyText();  // Başlangıçta para miktarını UI'de güncelle
    }

    void Update()
    {
        // UI'yi her frame'de güncelle
        UpdateMoneyText();
    }

    public void AddMoney(int amount)
    {
        money += amount;

        // Eğer para 0'ın altına düşerse, para miktarını sıfırla
        if (money < 0)
        {
            money = 0;
        }

        Debug.Log("Para eklendi: " + amount + ", Toplam para: " + money);

        // Para miktarını kaydet
        PlayerPrefs.SetInt(paraKey, money);
        PlayerPrefs.Save(); // Kaydedilen veriyi diske yaz

        UpdateMoneyText(); // Para eklendikten sonra metni güncelle
    }

    private void UpdateMoneyText()
    {
        moneyText.text = "" + money.ToString(); // Para miktarını metin bileşenine atayın
    }
}
