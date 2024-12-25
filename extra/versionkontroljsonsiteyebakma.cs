using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class versionkontroljson : MonoBehaviour
{

    public Text updateMessage;
    public Button updateButton;

    private string versionCheckUrl = "https://taha keskin/version.json";
    private string currentVersion = "30.0.0";  // Oyunun mevcut sürümü

    void Start()
    {
        StartCoroutine(CheckForUpdates());
    }

    IEnumerator CheckForUpdates()
    {
        UnityWebRequest www = UnityWebRequest.Get(versionCheckUrl);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            // JSON verisini parse et
            string jsonResponse = www.downloadHandler.text;
            VersionData versionData = JsonUtility.FromJson<VersionData>(jsonResponse);

            // Güncelleme kontrolü
            if (CompareVersions(currentVersion, versionData.latest_version) < 0)
            {
                ShowUpdateAlert(versionData.update_url);
            }
        }
        else
        {
            Debug.Log("Güncelleme kontrolü başarısız oldu: " + www.error);
        }
    }

    // Sürüm karşılaştırması
    int CompareVersions(string version1, string version2)
    {
        var v1 = version1.Split('.');
        var v2 = version2.Split('.');
        for (int i = 0; i < v1.Length; i++)
        {
            int val1 = int.Parse(v1[i]);
            int val2 = int.Parse(v2[i]);
            if (val1 < val2) return -1;
            if (val1 > val2) return 1;
        }
        return 0;
    }

    void ShowUpdateAlert(string updateUrl)
    {
        updateMessage.text = "Yeni bir sürüm mevcut! Lütfen güncelleyin.";
        updateButton.gameObject.SetActive(true);
        updateButton.onClick.AddListener(() => OpenUpdatePage(updateUrl));
    }

    void OpenUpdatePage(string url)
    {
        Application.OpenURL(url);
    }

    [System.Serializable]
    public class VersionData
    {
        public string latest_version;
        public string min_version;
        public string update_url;
    }

}
