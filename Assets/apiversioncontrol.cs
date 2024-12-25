using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Google.Play.AppUpdate;
using Google.Play.Common;

public class apiversioncontrol : MonoBehaviour
{
    // TextMeshProUGUI kullanarak referansı ekliyoruz
    [SerializeField] private TextMeshProUGUI inAppStatus;
    AppUpdateManager appUpdateManager;

    // Start is called before the first frame update
    void Start()
    {
        appUpdateManager = new AppUpdateManager();
        StartCoroutine(CheckForUpdate());
    }

    private IEnumerator CheckForUpdate()
    {
        PlayAsyncOperation<AppUpdateInfo, AppUpdateErrorCode> appUpdateInfoOperation =
            appUpdateManager.GetAppUpdateInfo();

        // Asenkron işlem tamamlanana kadar bekliyoruz
        yield return appUpdateInfoOperation;

        if (appUpdateInfoOperation.IsSuccessful)
        {
            var appUpdateInforResult = appUpdateInfoOperation.GetResult();

            // Eğer güncelleme varsa, TextMeshPro'yu aktif yap
            if (appUpdateInforResult.UpdateAvailability == UpdateAvailability.UpdateAvailable)
            {
                inAppStatus.text = "Update Available!";
                inAppStatus.gameObject.SetActive(true); // Text aktif
            }
            else
            {
                inAppStatus.gameObject.SetActive(false); // Text pasif
            }

            // Güncellemeyi başlatmayı unutmayalım
            var appUpdateOptions = AppUpdateOptions.ImmediateAppUpdateOptions();
            StartCoroutine(StartImmediateUpdate(appUpdateInforResult, appUpdateOptions));
        }
        else
        {
            // Eğer hata olursa, Text'i pasif yap
            inAppStatus.gameObject.SetActive(false); // Text pasif
        }
    }

    IEnumerator StartImmediateUpdate(AppUpdateInfo appUpdateInfoOp_i, AppUpdateOptions appUpdateOptions_i)
    {
        var startUpdateRequest = appUpdateManager.StartUpdate(
            appUpdateInfoOp_i,
            appUpdateOptions_i
        );
        yield return startUpdateRequest;

        // Güncelleme başarılı olduysa, bu satır hiç çalışmaz. Başarısız olursa burada işlem yapabilirsiniz.
    }
}
