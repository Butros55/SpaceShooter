using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonOnOff : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;

    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI = gameObject.GetComponent<TextMeshProUGUI>();
        LoadValues();
    }

    public void SetFullscreenButton() {
        if (textMeshProUGUI.text == "On") {
            PlayerPrefs.SetString("FullscreenText", "Off");
            PlayerPrefs.SetString("Fullscreen", "false");
            LoadValues();
        }
        else if (textMeshProUGUI.text == "Off") {
            PlayerPrefs.SetString("FullscreenText", "On");
            PlayerPrefs.SetString("Fullscreen", "true");
            LoadValues();
        }
    }

    private void LoadValues() {
        string FullScreen = PlayerPrefs.GetString("Fullscreen");
        string FullscreenText = PlayerPrefs.GetString("FullscreenText");

        if (FullScreen == "true") {
            Screen.fullScreen = true;
        }
        else if (FullScreen == "false") {
            Screen.fullScreen = false;
        }
        textMeshProUGUI.text = FullscreenText;
    }
}
