using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.EditorCoroutines.Editor;


public class IdleCat : EditorWindow {
    private Button catButton;
    private List<StyleBackground> idleBackgrounds = new List<StyleBackground>();
    private List<StyleBackground> pettingBackgrounds = new List<StyleBackground>();
    private int animationIndex = 0;
    private bool idle = true;
    private bool windowOpen = true;

    [MenuItem("Tools/I'm Lonely _%#K")] // the menu name
    public static void ShowIdleCat() {
        EditorWindow window = GetWindow<IdleCat>(); // opens the window or focuses if it is already open
        window.titleContent = new GUIContent("Kitty"); // the window name
        window.maxSize = new Vector2(100, 100);
        window.minSize = window.maxSize;
    }
    
    private void CreateGUI() {
        var root = rootVisualElement; // root of the Window
        var quickToolVisualTree = Resources.Load<VisualTreeAsset>("IdleCat"); // load the VisualTreeAsset
        quickToolVisualTree.CloneTree(root); // clone it
        
        catButton = root.Q<Button>("CatButton"); 
        catButton.tooltip = "meow";
        catButton.clicked += OnCatButtonClicked;
        
        Sprite[] allSprites = Resources.LoadAll<Sprite>("idleCat");

        for (int i = 0; i <= allSprites.Length - 1; i++) {
            StyleBackground backgroundImage = new StyleBackground(allSprites[i]);
            if (i < 11) {
                pettingBackgrounds.Add(backgroundImage);
            }

            if (i >= 10) {
                idleBackgrounds.Add(backgroundImage);
            }
        }

        EditorCoroutineUtility.StartCoroutine(NextAnimationFrame(), this);
    }

    private void OnCatButtonClicked() {
        Debug.Log("You're doing great!");
        idle = false;
    }
    
    IEnumerator NextAnimationFrame() {
        var waitForOneSecond = new EditorWaitForSeconds(1f);
        
        while (windowOpen) 
        {
            yield return waitForOneSecond;
            if (idle) {
                IdleAnimation();
            }
            else {
                PettingAnimation();
            }
        }
    }

    private void IdleAnimation() {
        animationIndex++;
        if (animationIndex >= idleBackgrounds.Count) {
            animationIndex = 0;
        }

        catButton.style.backgroundImage = idleBackgrounds[animationIndex];
    }
    
    private void PettingAnimation() {
        animationIndex++;
        if (animationIndex >= pettingBackgrounds.Count) {
            animationIndex = 0;
            idle = true;
        }

        catButton.style.backgroundImage = pettingBackgrounds[animationIndex];
    }
    
    private void OnDisable() {
        catButton.clicked -= OnCatButtonClicked;
        windowOpen = false;
    }
}
