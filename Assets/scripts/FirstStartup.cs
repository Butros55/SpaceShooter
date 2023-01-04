using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStartup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake() {
        if (!PlayerPrefs.HasKey("Fullscreen")) {
            PlayerPrefs.SetString("Fullscreen",  "true");
        }
        if (!PlayerPrefs.HasKey("FullscreenText")) {
            PlayerPrefs.SetString("FullscreenText",  "On");
        }
    }
}
