using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    // Bu metot, diğer objelerle çarpıştığında çağrılır
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Çarpan objeyi yok et
        StartCoroutine(DestroyAfterDelayCoroutine(other.gameObject));
    }

    // Coroutine, belirli bir süre bekledikten sonra objeyi yok eder
    private IEnumerator DestroyAfterDelayCoroutine(GameObject obj)
    {
        // 15 saniye bekle
        yield return new WaitForSeconds(10f);
        // Obje yok et
        Destroy(obj);
    }
}
