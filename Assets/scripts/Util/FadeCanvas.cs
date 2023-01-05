using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeCanvas : MonoBehaviour
{
     [SerializeField] private CanvasGroup myUI;
     [SerializeField] private bool fadeIn = false;
     [SerializeField] private bool fadeOut = false;
     [SerializeField] private bool fadeBack = false;
     [SerializeField] private float fadeBackafter;
    [SerializeField] private bool OnAwake = false;
    private bool SetTriggerOn = false;

    private void ShowUI() {
        fadeIn = true;
    }

    private void HideUI() {
        fadeOut = true;
    }

    private void FadeBack() {

        fadeBackafter -= Time.deltaTime;
        if (fadeBackafter <= 0) {
            fadeIn = true;
            fadeOut = false;
        }
    }

    public void TriggerOn() {
        SetTriggerOn = true;
    }

    private void Update() {
        if (SetTriggerOn || OnAwake) {
            Fade();
        }
    }

    private void Fade() {
        if (fadeIn) {
            if (myUI.alpha < 1) {
                myUI.alpha += Time.deltaTime / 2;
                if (myUI.alpha >= 1) {
                    fadeIn = false;
                }
            }
        }
        else if (fadeBack && fadeOut == false) {
            fadeBackafter -= Time.deltaTime;
            if (fadeBackafter <= 0) {
                fadeOut = true;
                fadeIn = false;
                fadeBack = false;
            }
        }

        if (fadeOut) {
            if (myUI.alpha >= 0) {
                myUI.alpha -= Time.deltaTime;
                if (myUI.alpha == 0) {
                    fadeOut = false;
                }
            }
        }
        else if (fadeBack && fadeIn == false) {
            fadeBackafter -= Time.deltaTime / 2;
            if (fadeBackafter <= 0) {
                fadeOut = true;
                fadeIn = false;
                fadeBack = false;
            }
        }
    }
}
