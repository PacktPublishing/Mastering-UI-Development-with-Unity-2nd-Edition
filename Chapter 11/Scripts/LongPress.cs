using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LongPress : MonoBehaviour {
    private bool buttonPressed = false;
    private float startTime = 0f;
    private float holdTime = 0f;
    [SerializeField] private float longHoldTime = 1f;
    [SerializeField] private Image radialFillImage;

    public void PressAndRelease(bool pressStatus) {
        buttonPressed = pressStatus;

        if (!buttonPressed) {
            holdTime = 0;
            radialFillImage.fillAmount = 0;
        }
        else {
            startTime = Time.time;
        }
    }

    void Update() {
        if (buttonPressed) {
            holdTime = Time.time - startTime;
            if (holdTime >= longHoldTime) {
                buttonPressed = false;
                LongPressCompleted();
            }
            else {
                radialFillImage.fillAmount = holdTime / longHoldTime;
            }
        }
    }

    public void LongPressCompleted() {
        radialFillImage.fillAmount = 0;
        Debug.Log("Do something after long press");
    }
}