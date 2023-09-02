using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour {
    [SerializeField] string currentLanguage; // key for the translation
    public List<DialogueBox> dialogueBoxes;
    [SerializeField] string nextScene; //name of the next scene

    int whichText = 0; //which dialogue we are currently reading
    int positionInString = 0; //which letter is being typed

    Coroutine textPusher; //so we can stop the coroutine
    
    void Awake() {
        Translate();
    }

    void Start() {
        textPusher = StartCoroutine(WriteTheText());
    }

    /// <summary>
    /// Will make the text look as if it is typing out.
    /// </summary>
    IEnumerator WriteTheText() {
        for (int i = 0; i <= dialogueBoxes[whichText].dialogue.Length; i++){
            dialogueBoxes[whichText].textDisplayBox.text = dialogueBoxes[whichText].dialogue.Substring(0,i);
            positionInString ++;
            yield return new WaitForSeconds(0.1f);
        }
    }

    /// <summary>
    /// Will proceed to the next text box.
    /// </summary>
    public void ProceedText() {
        //haven't made it to the end of the string
        if (positionInString < dialogueBoxes[whichText].dialogue.Length){
            //stop typing the text
            StopCoroutine(textPusher);
            
            //show the full string
            dialogueBoxes[whichText].textDisplayBox.text = dialogueBoxes[whichText].dialogue;
            positionInString = dialogueBoxes[whichText].dialogue.Length;

        //have completed the whole string
        } else {
            //hide the text holder
            ToggleCanvasGroup(dialogueBoxes[whichText].textHolder, false);

            //proceed to next string
            whichText ++;

            //there's no more text, go to the next scene
            if (whichText >= dialogueBoxes.Count) {
                SceneManager.LoadScene(nextScene);

                //there are more text boxes
            } else {
                positionInString = 0;
                ToggleCanvasGroup(dialogueBoxes[whichText].textHolder, true);
                textPusher = StartCoroutine(WriteTheText());
            }
        }
    }

    public void ToggleCanvasGroup(CanvasGroup panel, bool show) {
        panel.alpha = Convert.ToInt32(show);
        panel.interactable = show;
        panel.blocksRaycasts = show;
    }

    private void Translate() {
        foreach (DialogueBox dialogueBox in dialogueBoxes) {
            int index = dialogueBox.translations.FindIndex(x => x.languageKey == currentLanguage);
            if (index >= 0) {
                dialogueBox.dialogue = dialogueBox.translations[index].translatedString;
                dialogueBox.textDisplayBox.font = dialogueBox.translations[index].font;
                dialogueBox.textDisplayBox.fontStyle = dialogueBox.translations[index].fontStyle;
            }
        }
    }
}