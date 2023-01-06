using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionMenu : MonoBehaviour
{
    public TMP_Dropdown resolutionsDropdown;
    public TMP_Dropdown qualityLevelDropdown;
    public TextMeshProUGUI VsyncText;
    public TextMeshProUGUI FullscreenText;
    Resolution[] resolutions;

    void Start() {
        resolutions = Screen.resolutions;

        resolutionsDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height &&
                !PlayerPrefs.HasKey("ResolutionIndex")) {
                PlayerPrefs.SetInt("ResolutionIndex", i);
            }
        }

        resolutionsDropdown.AddOptions(options);

        LoadValues();
    }

    public void SetQuality(int qualityIndex) {
        PlayerPrefs.SetInt("QualityLevel", qualityIndex);
        LoadValues();
    }

    public void SetResolution(int resolutionIndex) {
        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
        LoadValues();
    }

    public void SetVsync() {
        if (QualitySettings.vSyncCount == 1) {
            PlayerPrefs.SetInt("Vsync", 0);
            PlayerPrefs.SetString("VsyncText", "Off");
        }
        else {
            PlayerPrefs.SetInt("Vsync", 1);
            PlayerPrefs.SetString("VsyncText", "On");
        }
        LoadValues();
    }

    public void SetFullscreenButton() {
        if (Screen.fullScreen == true) {
            PlayerPrefs.SetString("FullscreenText", "Off");
            PlayerPrefs.SetString("Fullscreen", "false");
        }
        else if (Screen.fullScreen == false) {
            PlayerPrefs.SetString("FullscreenText", "On");
            PlayerPrefs.SetString("Fullscreen", "true");
        }
        LoadValues();
    }

    private void LoadValues() {
        int qualityIndex = PlayerPrefs.GetInt("QualityLevel");
        qualityLevelDropdown.value = qualityIndex;
        QualitySettings.SetQualityLevel(qualityIndex);

        int resolutionIndex = PlayerPrefs.GetInt("ResolutionIndex");
        resolutionsDropdown.value = resolutionIndex;
        resolutionsDropdown.RefreshShownValue();
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        int Vsync = PlayerPrefs.GetInt("Vsync");
        string VsyncTextSettings = PlayerPrefs.GetString("VsyncText");
        QualitySettings.vSyncCount = Vsync;
        VsyncText.text = VsyncTextSettings;

        string FullScreen = PlayerPrefs.GetString("Fullscreen");
        string FullscreenTextSettings = PlayerPrefs.GetString("FullscreenText");

        if (FullScreen == "true") {
            Screen.fullScreen = true;
        }
        else if (FullScreen == "false") {
            Screen.fullScreen = false;
        }
        FullscreenText.text = FullscreenTextSettings;
    }
}
