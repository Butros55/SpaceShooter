using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{

    [SerializeField] private bool ObjectToNextScreen = false;
    [SerializeField] private string Scene;
    [SerializeField] private float ChangeAfterSec;
    [SerializeField] private bool OnAwake = false;

    private void Awake() {
        if (ObjectToNextScreen) {
        DontDestroyOnLoad(gameObject);
        }
    }
    private void Start() {
        if (OnAwake) {
            ChangeSceneTo();
        }
    }
    // Start is called before the first frame update
    public void ChangeSceneTo() {
        Time.timeScale = 1f;
        Invoke("LoadScene", ChangeAfterSec);
    }

    // Update is called once per frame
    void LoadScene() {
        SceneManager.LoadScene(Scene);
    }
}
