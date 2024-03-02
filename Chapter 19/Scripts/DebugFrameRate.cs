using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugFrameRate : MonoBehaviour {
    int fps;
    private string fpsString;
    [SerializeField] int fpsThreshold;
    private void OnGUI() {
        if (fps < fpsThreshold) {
            GUI.contentColor = Color.red;
        }
        else {
            GUI.contentColor = Color.white;
        }

        GUI.Label(new Rect(10, 10, 100, 50), "fps = " + fps.ToString());
    }

    private void Update() {
        fps = (int)(1f / Time.unscaledDeltaTime);
    }
}
