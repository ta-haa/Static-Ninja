using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arabadegdiniyoket : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Belirtilen taglere sahip nesneleri yok et
        if (other.gameObject.CompareTag("bull1") || other.gameObject.CompareTag("bull2") || other.gameObject.CompareTag("enemies1"))
        {
            Destroy(other.gameObject);
        }
    }
}
