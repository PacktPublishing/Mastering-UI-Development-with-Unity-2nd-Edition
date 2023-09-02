using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour {
    public CanvasGroup canvasGroup;

    void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ToggleCanvasGroup(bool show) {
        canvasGroup.alpha = Convert.ToInt32(show);
        canvasGroup.interactable = show;
        canvasGroup.blocksRaycasts = show;
    }
}
