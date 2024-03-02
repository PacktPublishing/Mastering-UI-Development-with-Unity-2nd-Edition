using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter19Labels : MonoBehaviour {
    public Texture2D labelTexture;

    private void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 50), "Text Label");
        GUI.Label(new Rect(10, 80, 50, 50), labelTexture);
    }
}
