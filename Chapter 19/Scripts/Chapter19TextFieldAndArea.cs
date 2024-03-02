using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter19TextFieldAndArea : MonoBehaviour {
    private string textFieldText = "Enter text";
    private string textAreaText = "Enter text";
    private void OnGUI() {
        textFieldText = GUI.TextField(new Rect(10, 10, 100, 50), textFieldText);
        textAreaText = GUI.TextArea(new Rect(10, 80, 100, 100), textAreaText);
    }
}
