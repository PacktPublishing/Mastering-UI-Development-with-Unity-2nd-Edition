using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogueBox {
    public string dialogue;
    public CanvasGroup textHolder;
    public Text textDisplayBox;
    
    public List<Translation> translations;
    
    [System.Serializable]
    public class Translation {
        public string languageKey;
        public string translatedString;
        public Font font;
        public FontStyle fontStyle;
    }
}
