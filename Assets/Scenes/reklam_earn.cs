using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class ReklamEarn : MonoBehaviour
{
    // Bu reklam birimleri her zaman test reklamları gösterecek şekilde ayarlandı.
#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
    private string _adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
    private string _adUnitId = "unused";
#endif

    private RewardedAd _rewardedAd;

    public Player player;  // Player scriptine referans (para eklemek için)

    public void Start()
    {
        // Google Mobile Ads SDK'yı başlat
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // SDK başlatıldıktan sonra yapılacak işlemler
        });

        // Reklamı yükle
        LoadRewardedAd();
    }

    /// <summary>
    /// Ödüllü reklamı yükler.
    /// </summary>
    public void LoadRewardedAd()
    {
        // Eski reklamı temizle
        if (_rewardedAd != null)
        {
            _rewardedAd.Destroy();
            _rewardedAd = null;
        }

        Debug.Log("Ödüllü reklam yükleniyor.");

        // Reklam yüklemek için istek oluştur
        var adRequest = new AdRequest();

        // Reklamı yüklemek için istek gönder
        RewardedAd.Load(_adUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    Debug.LogError("Ödüllü reklam yüklenemedi: " + error);
                    return;
                }

                Debug.Log("Ödüllü reklam yüklendi: " + ad.GetResponseInfo());

                _rewardedAd = ad;

                // Reklam yüklendikten sonra yeniden yükleme işlemi için event handler ekle
                RegisterReloadHandler(_rewardedAd);
            });
    }

    public void ShowRewardedAd()
    {
        const string rewardMsg = "Ödüllü reklam oyuncuyu ödüllendirdi. Tür: {0}, miktar: {1}.";

        if (_rewardedAd != null && _rewardedAd.CanShowAd())
        {
            _rewardedAd.Show((Reward reward) =>
            {
                // Ödül verildiğinde para ekle
                if (player != null)
                {
                    int rewardAmount = 100;  // 100 para ver
                    player.AddMoney(rewardAmount);  // Para ekleme işlemi
                    Debug.Log(string.Format(rewardMsg, reward.Type, reward.Amount));
                }
            });
        }
    }

    private void RegisterReloadHandler(RewardedAd ad)
    {
        // Reklam kapatıldığında yeniden yükle
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Ödüllü reklam kapatıldı.");

            // Yeni reklamı yükle
            LoadRewardedAd();
        };

        // Reklam açılmada hata olursa yeniden yükle
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Ödüllü reklam açılırken hata: " + error);

            // Yeni reklamı yükle
            LoadRewardedAd();
        };
    }
}
