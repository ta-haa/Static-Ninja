using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player player; // Bu, düşmanın referansını tutacağı oyuncu objesi
    public int moneyReward = 10; // Inspector'dan değiştirilebilir para miktarı

    void OnDestroy()
    {
        if (player != null)
        {
            player.AddMoney(moneyReward); // Düşman öldüğünde oyuncuya para ekle
        }
    }
}
