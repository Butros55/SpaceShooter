using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FirstStartup : MonoBehaviour
{
    public AudioMixer MusicMixer;

    private void Awake() {
        if (!PlayerPrefs.HasKey("Fullscreen")) {
            PlayerPrefs.SetString("Fullscreen",  "true");
        }
        if (!PlayerPrefs.HasKey("FullscreenText")) {
            PlayerPrefs.SetString("FullscreenText",  "On");
        }
        if (!PlayerPrefs.HasKey("MasterVolume")) {
            PlayerPrefs.SetFloat("MasterVolume", -40);
        }
        if (!PlayerPrefs.HasKey("MusicVolume")) {
            PlayerPrefs.SetFloat("MusicVolume", 0);
        }
        if (!PlayerPrefs.HasKey("Vsync")) {
            PlayerPrefs.SetInt("Vsync", 1);
            PlayerPrefs.SetString("VsyncText", "On");
        }
        if (!PlayerPrefs.HasKey("Fullscreen")) {
            PlayerPrefs.SetString("Fullscreen", "true");
            PlayerPrefs.SetString("FullscreenText", "On");
            Screen.fullScreen = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadValues();
    }
    
    void LoadValues() {
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume");
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        MusicMixer.SetFloat("Volume", musicVolume);
        AudioListener.volume = masterVolume;

        int Vsync = PlayerPrefs.GetInt("Vsync");
        QualitySettings.vSyncCount = Vsync;
    }
}
