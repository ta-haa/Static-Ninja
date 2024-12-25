using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.Networking;  // UnityWebRequest için gerekli namespace
using System.IO;

public class LanguageManager : MonoBehaviour
{
    public TMP_Text startGameText;
    public TMP_Text settingsText;
    public TMP_Text exitText;
    public TMP_Text levelText;
    public TMP_Text scoreText;
    public TMP_Text pauseText;
    public TMP_Text resumeText;
    public TMP_Text restartText;
    public TMP_Text mainMenuText;
    public TMP_Text soundText;
    public TMP_Text musicText;
    public TMP_Text languageText;
    public TMP_Text helpText;
    public TMP_Text exitGameText;
    public TMP_Text confirmText;
    public TMP_Text cancelText;
    public TMP_Text settingsTitleText;
    public TMP_Text backText;
    public TMP_Text nextText;
    public TMP_Text previousText;
    public TMP_Text continueText;
    public TMP_Text tryagainText;
    public TMP_Text backmenuText;
    public TMP_Text languageTxt;
    public TMP_Text versionTxt;
    public TMP_Text carkismiTxt;
    public TMP_Text scaleTxt;
    public TMP_Text changeTxt;
    public TMP_Text starTxt;

    public TMP_Text motivationone;
    public TMP_Text motivationtwo;
    public TMP_Text motivationthree;
    public TMP_Text entehlikeliadam;


    public TMP_Dropdown languageDropdown;

    private Dictionary<string, string> currentLanguageDictionary;

    private static LanguageManager _instance;

    public static LanguageManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("LanguageManager");
                _instance = obj.AddComponent<LanguageManager>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    public void SaveLanguagePreference(string language)
    {
        PlayerPrefs.SetString("PreferredLanguage", language);
        PlayerPrefs.Save();
    }

    private void Start()
    {
        string language = PlayerPrefs.GetString("PreferredLanguage", "english");
        ChangeLanguage(language);
        UpdateDropdownSelection(language);
        PopulateDropdown();
    }

    public void OnLanguageChanged(int index)
    {
        string selectedLanguage = languageDropdown.options[index].text.ToLower();
        ChangeLanguage(selectedLanguage);
        SaveLanguagePreference(selectedLanguage);
    }

    public void ChangeLanguage(string language)
    {
        string path = Path.Combine(Application.streamingAssetsPath, language + ".json");

        // UnityWebRequest ile JSON dosyasını okumaya çalışıyoruz
        StartCoroutine(LoadLanguageJson(path));
    }

    private IEnumerator<UnityWebRequestAsyncOperation> LoadLanguageJson(string path)
    {
        UnityWebRequest www;

        // Android için doğru erişim yolu
        if (path.Contains("://"))
        {
            // Android için UnityWebRequest ile dosya yolunu belirt
            www = UnityWebRequest.Get(path);
        }
        else
        {
            // Editör (PC/Mac) için dosya yolunu 'file://' olarak belirt
            www = UnityWebRequest.Get("file://" + path);
        }

        // Dosyayı indirmeye başla
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Hata: " + www.error);
        }
        else
        {
            string jsonString = www.downloadHandler.text;
            currentLanguageDictionary = JsonUtility.FromJson<DictionaryWrapper>(jsonString).toDictionary();
            UpdateText();
        }
    }

    private void UpdateText()
    {
        if (startGameText != null) { startGameText.text = currentLanguageDictionary["T1"]; }
        if (settingsText != null) { settingsText.text = currentLanguageDictionary["T2"]; }
        if (exitText != null) { exitText.text = currentLanguageDictionary["T3"]; }
        if (levelText != null) { levelText.text = currentLanguageDictionary["T4"]; }
        if (scoreText != null) { scoreText.text = currentLanguageDictionary["T5"]; }
        if (pauseText != null) { pauseText.text = currentLanguageDictionary["T6"]; }
        if (resumeText != null) { resumeText.text = currentLanguageDictionary["T7"]; }
        if (restartText != null) { restartText.text = currentLanguageDictionary["T8"]; }
        if (mainMenuText != null) { mainMenuText.text = currentLanguageDictionary["T9"]; }
        if (soundText != null) { soundText.text = currentLanguageDictionary["T10"]; }
        if (musicText != null) { musicText.text = currentLanguageDictionary["T11"]; }
        if (languageText != null) { languageText.text = currentLanguageDictionary["T12"]; }
        if (helpText != null) { helpText.text = currentLanguageDictionary["T13"]; }
        if (exitGameText != null) { exitGameText.text = currentLanguageDictionary["T14"]; }
        if (confirmText != null) { confirmText.text = currentLanguageDictionary["T15"]; }
        if (cancelText != null) { cancelText.text = currentLanguageDictionary["T16"]; }
        if (settingsTitleText != null) { settingsTitleText.text = currentLanguageDictionary["T17"]; }
        if (backText != null) { backText.text = currentLanguageDictionary["T18"]; }
        if (nextText != null) { nextText.text = currentLanguageDictionary["T19"]; }
        if (previousText != null) { previousText.text = currentLanguageDictionary["T20"]; }
        if (continueText != null) { continueText.text = currentLanguageDictionary["T21"]; }
        if (tryagainText != null) { tryagainText.text = currentLanguageDictionary["T22"]; }
        if (backmenuText != null) { backmenuText.text = currentLanguageDictionary["T23"]; }
        if (languageTxt != null) { languageTxt.text = currentLanguageDictionary["T24"]; }
        if (versionTxt != null) { versionTxt.text = currentLanguageDictionary["T25"]; }
        if (carkismiTxt != null) { carkismiTxt.text = currentLanguageDictionary["T26"]; }
        if (scaleTxt != null) { scaleTxt.text = currentLanguageDictionary["T27"]; }
        if (changeTxt != null) { changeTxt.text = currentLanguageDictionary["T28"]; }
        if (starTxt != null) { starTxt.text = currentLanguageDictionary["T29"]; }
        if (motivationone != null) { motivationone.text = currentLanguageDictionary["T30"]; }
        if (motivationtwo != null) { motivationtwo.text = currentLanguageDictionary["T31"]; }
        if (motivationthree != null) { motivationthree.text = currentLanguageDictionary["T32"]; }
        if (entehlikeliadam != null) { entehlikeliadam.text = currentLanguageDictionary["T33"]; }
    }

    private void UpdateDropdownSelection(string language)
    {
        int selectedIndex = languageDropdown.options.FindIndex(option => option.text.ToLower() == language);
        languageDropdown.value = selectedIndex >= 0 ? selectedIndex : 0;
    }

    private void PopulateDropdown()
    {
        // Clear any existing options
        languageDropdown.ClearOptions();

        // Get all language files in the StreamingAssets folder
        string[] languageFiles = Directory.GetFiles(Application.streamingAssetsPath, "*.json");

        // Extract language names from file names
        List<string> languages = new List<string>();
        foreach (string file in languageFiles)
        {
            // File names in StreamingAssets folder
            string fileName = Path.GetFileNameWithoutExtension(file).ToLower();
            languages.Add(fileName);
        }

        // Add languages to the dropdown
        languageDropdown.AddOptions(languages);

        // Set the selected language
        string savedLanguage = PlayerPrefs.GetString("PreferredLanguage", "english");
        UpdateDropdownSelection(savedLanguage);
    }

    [System.Serializable]
    public class DictionaryWrapper
    {
        public List<LanguageEntry> entries;

        public Dictionary<string, string> toDictionary()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (var entry in entries)
            {
                dictionary[entry.key] = entry.value;
            }
            return dictionary;
        }
    }

    [System.Serializable]
    public class LanguageEntry
    {
        public string key;
        public string value;
    }
}
