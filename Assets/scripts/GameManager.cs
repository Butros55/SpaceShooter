using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int Score;

    public bool GameOver = false;

    // Start is called before the first frame update
    private void Awake() {
        instance = this;
    }
}
