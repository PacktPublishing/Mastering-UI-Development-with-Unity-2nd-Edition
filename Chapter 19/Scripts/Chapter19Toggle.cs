using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter19Toggle : MonoBehaviour {
    private bool toggleBool = true;
    private void OnGUI() {
        toggleBool = GUI.Toggle(new Rect(10, 10, 100, 50), toggleBool,"Toggle Me");
    }
}
