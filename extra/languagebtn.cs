using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class languagebtn : MonoBehaviour
{

    public void OnEnglishButtonClicked()
    {
        LanguageManager.Instance.ChangeLanguage("english");
    }

    public void OnTurkishButtonClicked()
    {
        LanguageManager.Instance.ChangeLanguage("turkish");
    }

}
