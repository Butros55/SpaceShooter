using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider MasterSlider;
    public Slider MusicSlider;
    public AudioMixer MusicMixer;

    private void Awake() {
        LoadVolumes();
    }
    public void SetMasterVolume(float volume) {
        PlayerPrefs.SetFloat("MasterVolume", volume);
        LoadVolumes();
    }

    public void SetMusicVolume(float volume) {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        LoadVolumes();
    }

    void LoadVolumes() {
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume");
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        MusicMixer.SetFloat("Volume", musicVolume);
        AudioListener.volume = masterVolume;
        MasterSlider.value = masterVolume;
        MusicSlider.value = musicVolume;
    }
}
