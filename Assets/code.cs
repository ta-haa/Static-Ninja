using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class code : MonoBehaviour
{
    private UpDown upDown; // UpDown sınıfına referans

    void Start()
    {
        upDown = FindObjectOfType<UpDown>(); // UpDown bileşenini bul
        if (upDown == null)
        {
            Debug.LogError("UpDown bileşeni bulunamadı!"); // Hata mesajı
        }
    }

    public void knifebtn()
    {
        if (upDown != null)
        {
            upDown.ThrowKnife();
        }
    }

    public void firebtn()
    {
        if (upDown != null)
        {
            upDown.ThrowFire();
        }
    }

    public void jumpbtn()
    {
        if (upDown != null)
        {
            upDown.Jump();
        }
    }

    public void shieldbtn()
    {
        if (upDown != null)
        {
            StartCoroutine(upDown.ActivateShield());
        }
    }

    public void clonebtn()
    {
        if (upDown != null)
        {
            upDown.ClonePlayer();
        }
    }

    public void portalbtn()
    {
        if (upDown != null)
        {
            upDown.PortalPlayer();
        }
    }
}
