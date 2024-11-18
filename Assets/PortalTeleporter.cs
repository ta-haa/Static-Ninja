using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    // 2. portalın transformunu buraya drag and drop ile atayın
    public Transform portal2Location;

    // Karakterin Portal1'e çarpma anında gerçekleşecek işlem
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Karakterin objesiyle çarpma kontrolü
        if (other.CompareTag("Player"))
        {
            // Karakteri Portal2'ye ışınla, sadece x ve y koordinatlarını kullanarak
            other.transform.position = new Vector3(portal2Location.position.x, portal2Location.position.y, other.transform.position.z);
        }
    }
}
