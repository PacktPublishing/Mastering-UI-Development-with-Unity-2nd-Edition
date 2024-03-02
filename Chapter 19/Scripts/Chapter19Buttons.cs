using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter19Buttons : MonoBehaviour {
    public Texture2D buttonTexture;

    private void OnGUI() {
        if (GUI.Button(new Rect(10, 10, 100, 50), "Text Button")) {
            Debug.Log("Text Button Clicked");
        }

        if (GUI.Button(new Rect(10, 80, 50, 50), buttonTexture)) {
            Debug.Log("Image Button Clicked");
        }
    }
}
