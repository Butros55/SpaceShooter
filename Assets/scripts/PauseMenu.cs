using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu, optionsMenu;
    // Start is called before the first frame update
    void Update() {
        if (Input.GetButtonDown("Pause")) {
            PauseUnpause();
        }
    }

    // Update is called once per frame
    public void PauseUnpause() {
        if (!pauseMenu.activeInHierarchy && !optionsMenu.activeInHierarchy) {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (pauseMenu.activeInHierarchy && !optionsMenu.activeInHierarchy) {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
