using System.Collections;
using UnityEngine;
#if UNITY_IOS
using UnityEngine.iOS;
#elif UNITY_ANDROID
using Google.Play.Review;
#endif

public class AppRating : MonoBehaviour
{
#if UNITY_ANDROID
    private ReviewManager _reviewManager;
    private PlayReviewInfo _playReviewInfo;
    private Coroutine _coroutine;
#endif

    private void Start()
    {
#if UNITY_ANDROID
        _coroutine = StartCoroutine(InitReview());
#endif
    }

    public void RateAndReview()
    {
#if UNITY_IOS
        // iOS'da, kullanıcıdan uygulama değerlendirmesi istemek için App Store review penceresini açıyoruz.
        Device.RequestStoreReview();
#elif UNITY_ANDROID
        // Android'de, kullanıcıyı Google Play'deki değerlendirme penceresine yönlendiriyoruz.
        StartCoroutine(LaunchReview());
#endif
    }

#if UNITY_ANDROID
    private IEnumerator InitReview(bool force = false)
    {
        if (_reviewManager == null) _reviewManager = new ReviewManager();

        var requestFlowOperation = _reviewManager.RequestReviewFlow();
        yield return requestFlowOperation;
        if (requestFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Eğer sorun olursa, doğrudan Google Play sayfasını açıyoruz.
            if (force) DirectlyOpen();
            yield break;
        }

        _playReviewInfo = requestFlowOperation.GetResult();
    }

    public IEnumerator LaunchReview()
    {
        // Eğer review flow bilgisi yoksa, baştan başlatıyoruz.
        if (_playReviewInfo == null)
        {
            if (_coroutine != null) StopCoroutine(_coroutine);
            yield return StartCoroutine(InitReview(true));
        }

        var launchFlowOperation = _reviewManager.LaunchReviewFlow(_playReviewInfo);
        yield return launchFlowOperation;
        _playReviewInfo = null;
        if (launchFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Eğer hata varsa, doğrudan Play Store sayfasını açıyoruz.
            DirectlyOpen();
            yield break;
        }
    }
#endif

    private void DirectlyOpen()
    {
#if UNITY_ANDROID
        // Android için Google Play Store sayfasını açıyoruz
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.taha.keskin");
#elif UNITY_IOS
        // iOS için App Store sayfasını açıyoruz
        Application.OpenURL("https://apps.apple.com/us/app/idYOUR_APP_ID");
#endif
    }
}
