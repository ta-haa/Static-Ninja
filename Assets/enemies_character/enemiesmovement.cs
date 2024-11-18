using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    void Start()
    {
        // Hızı rastgele bir değerle ayarla (1 ile 3 arasında)
        speed = Random.Range(0.5f, 1f);
    }

    void Update()
    {
        // Düşmanın sola doğru hareket etmesini sağla
        transform.Translate(Vector3.left * speed * Time.deltaTime);


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Eğer karaktere çarparsa
        {
            Destroy(gameObject); // Düşmanı yok et 
        }
        else if (other.CompareTag("fire")) // Eğer ateşe çarparsa
        {
            Destroy(gameObject); // Düşmanı yok et 
        }
        else if (other.CompareTag("knife")) // Eğer bıçağa çarparsa
        {
            Destroy(gameObject); // Düşmanı yok et 
        }
        else if (other.CompareTag("shield")) // Eğer kalkana çarparsa
        {
            Destroy(gameObject); // Düşmanı yok et 
        }
        else if (other.CompareTag("clone")) // Eğer klona çarparsa
        {
            Destroy(gameObject); // Düşmanı yok et 
        }
    }
}
