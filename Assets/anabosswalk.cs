using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anabosswalk : MonoBehaviour
{
    private float speed;

    // Bu fonksiyon, düşman objesi yaratıldığında çağrılacak
    void Start()
    {
        // Hızı rastgele bir değerle ayarla (0.5 ile 3 arasında)
        speed = Random.Range(0.5f, 3f);
    }

    // Bu fonksiyon her frame çalışacak
    void Update()
    {
        // Düşmanı sola doğru hareket ettir (x ekseninde -speed)
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
