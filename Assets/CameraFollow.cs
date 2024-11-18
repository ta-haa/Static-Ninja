using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek nesne
    public float smoothSpeed = 0.125f; // Kameranın yumuşak hareket hızı
    public Vector3 offset; // Kamera ile hedef arasındaki mesafe

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset; // Hedefin pozisyonu ile offset'in toplamı
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Yumuşak geçiş
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z); // Z pozisyonunu sabit tut
        }
    }
}

