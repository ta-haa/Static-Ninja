using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    void Start()
    {
        // Hızı rastgele bir değerle ayarla (1 ile 3 arasında)
        speed = Random.Range(0.1f, 5f);
    }

    void Update()
    {
        // Düşmanın sola doğru hareket etmesini sağla
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void oll()
    {
        // Öldü diyelim, burada düşmanı yok etmek için:
        Destroy(gameObject); // Düşmanı yok et
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player")) // Eğer karaktere çarparsa
        {
            oll();
        }
        else if (collision.gameObject.CompareTag("fire")) // Eğer ateşe çarparsa
        {
            oll();
        }
        else if (collision.gameObject.CompareTag("knife")) // Eğer bıçağa çarparsa
        {
            oll();
        }
        else if (collision.gameObject.CompareTag("shield")) // Eğer kalkana çarparsa
        {
            oll();
        }
        else if (collision.gameObject.CompareTag("clone")) // Eğer klona çarparsa
        {
            oll();
        }
        else if (collision.gameObject.CompareTag("simsek")) // Eğer simseğe çarparsa
        {
            oll();
        }
        else if (collision.gameObject.CompareTag("laser")) // Eğer lazere çarparsa
        {
            oll();
        }
        else if (collision.gameObject.CompareTag("my_car")) // Eğer lazere çarparsa
        {
            oll();
        }
    }
}
