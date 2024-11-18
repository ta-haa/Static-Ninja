using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QualitySettingsManager : MonoBehaviour
{
    public Dropdown qualityDropdown;

    void Start()
    {
        // Populate the dropdown with the available quality settings
        PopulateQualityDropdown();
        QualitySettings.SetQualityLevel(5);  // Max Quality Level
        // Retrieve saved quality level, defaulting to 2 (Medium)
        int qualityLevel = PlayerPrefs.GetInt("Quality", 2);
        qualityDropdown.value = qualityLevel;

        // Add listener for when the dropdown value changes
        qualityDropdown.onValueChanged.AddListener(SetQuality);
    }

    void PopulateQualityDropdown()
    {
        string[] qualityNames = QualitySettings.names;

        // Clear any existing options in the dropdown
        qualityDropdown.ClearOptions();

        // Add the quality names as dropdown options
        qualityDropdown.AddOptions(new List<string>(qualityNames));
    }

    public void SetQuality(int qualityIndex)
    {
        // Debug log to check if quality index is being set correctly
        Debug.Log("Changing quality to index: " + qualityIndex);

        // Set the quality level based on the dropdown selection
        QualitySettings.SetQualityLevel(qualityIndex);

        // Save the selected quality level in PlayerPrefs
        PlayerPrefs.SetInt("Quality", qualityIndex);
        PlayerPrefs.Save(); // Explicit save, can be omitted as Unity auto-saves
    }
}
