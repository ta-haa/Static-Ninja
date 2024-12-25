using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class apigoogle : MonoBehaviour
{
    void Start()
    {
        PlayGamesPlatform.Activate();
        Debug.Log("Play Games API etkinleştirildi");
    }

    public void SignIn()
    {
        Debug.Log("Giriş işlemi başlatılıyor...");
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Giriş başarılı!");
            }
            else
            {
                Debug.Log("Giriş başarısız.");
            }
        });
    }

    public void ShowLeaderboard()
    {
        if (Social.localUser.authenticated)
        {
            Debug.Log("Liderlik tablosu açılıyor...");
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
        else
        {
            Debug.Log("Kullanıcı giriş yapmamış.");
        }
    }
}
