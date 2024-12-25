using System.Collections;
using System.Collections.Generic;
using UnityEngine;




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillbtn : MonoBehaviour
{
    public Skill newSkill;  // Yeni açılacak beceriye referans

    void Start()
    {
        // Oyun başladığında, beceriyi yükleyelim
        if (newSkill != null)
        {
            newSkill.LoadSkill(); // Beceriyi yükleyelim
        }
    }

    public void skillsimsek()
    {
        // Yeni beceri açma işlemi
        if (newSkill != null)
        {
            newSkill.UnlockSkill();  // Beceriyi açıyoruz
        }
    }
}
