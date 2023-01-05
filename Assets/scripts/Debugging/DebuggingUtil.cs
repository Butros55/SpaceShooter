using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DebuggingUtil : MonoBehaviour
{
    private float time;
    private float pollingTime = 1f;
    private int frameCount;
    public TextMeshProUGUI FpsText;
    private bool showFps = false;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("ShowFps")) {
            if (showFps == false) {
                showFps = true;
            }
            else
            {
                showFps = false;
                FpsText.text = "";
            }
        }


            time += Time.deltaTime;
            frameCount++;
        if (showFps) {
            if (time >= pollingTime) {
                int frameRate = Mathf.RoundToInt(frameCount / time);
                FpsText.text = frameRate.ToString() + " FPS";

                time -= pollingTime;
                frameCount = 0;
            }
        }
    }
}

