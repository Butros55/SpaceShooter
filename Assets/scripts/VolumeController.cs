using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    public AudioMixer MasterMixer;
    public AudioMixer MusicMixer;

    private void Start() {
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
        MasterMixer.SetFloat("Volume", masterVolume);
    }
}
