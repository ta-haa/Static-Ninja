using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class reklam : MonoBehaviour
{
    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
  private string _adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
  private string _adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
    private string _adUnitId = "unused";
#endif

    private InterstitialAd _interstitialAd;


    // Unity Ads ID'leri (bunları Unity Ads dashboard'undan alacaksınız)
    private string gameId = "YOUR_GAME_ID";  // Unity oyun ID'niz
    private string rewardAdId = "Rewarded_Android"; // Reklam ID'si
    private string interstitialAdId = "Interstitial_Android"; // Geçici Reklam ID'si



    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
        });

        LoadInterstitialAd();
    }



    // Call this when the character dies
    public void OnCharacterDeath()
    {

        // Show the interstitial ad
        ShowInterstitialAd();

        // Wait for the ad to finish before transitioning to the main menu
        StartCoroutine(WaitForAdAndLoadMainMenu());

    }

    private IEnumerator WaitForAdAndLoadMainMenu()
    {
        // Wait for the ad to close (you may need to hook into the ad's callback here)
        yield return new WaitForSeconds(0.3f); // Adjust delay based on how long the ad lasts

        // Load the main menu scene
        SceneManager.LoadScene("SampleScene");
    }


    /// <summary>
    /// Loads the interstitial ad.
    /// </summary>
    public void LoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        InterstitialAd.Load(_adUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                          + ad.GetResponseInfo());

                _interstitialAd = ad;

            });

    }


    //////////////// Reklam gosterme
    /// <summary>
    /// Shows the interstitial ad.
    /// </summary>
    public void ShowInterstitialAd()
    {
        if (_interstitialAd != null && _interstitialAd.CanShowAd())
        {
            Debug.Log("Showing interstitial ad.");
            _interstitialAd.Show();
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
        }
    }

}
