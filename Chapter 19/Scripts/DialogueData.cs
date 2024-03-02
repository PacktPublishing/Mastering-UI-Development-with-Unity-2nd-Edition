using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SO", menuName = "DialogueData", order = 1)]
public class DialogueData : ScriptableObject {
    public string textPath;
    public List<string> importedDialogue;
}