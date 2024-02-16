using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Chapter18EventsExample : MonoBehaviour {
    [SerializeField] private UIDocument uiDocument;
    private Label dogLabel;
    private Button catButton;
    void Start() {
        var root = uiDocument.rootVisualElement;
        dogLabel = root.Q<Label>("DogLabel");
        catButton = root.Query<Button>("CatButton");

        catButton.clicked += OnCatButtonClicked;
    }

    private void OnCatButtonClicked() {
        Debug.Log("CatButtonClicked");
        dogLabel.text = "Meow!";
    }

    private void OnDisable() {
        catButton.clicked -= OnCatButtonClicked;
    }
}
