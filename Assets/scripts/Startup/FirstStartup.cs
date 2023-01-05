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
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadVolumes();
    }
    
    void LoadVolumes() {
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume");
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        MusicMixer.SetFloat("Volume", musicVolume);
        AudioListener.volume = masterVolume;
    }
}
