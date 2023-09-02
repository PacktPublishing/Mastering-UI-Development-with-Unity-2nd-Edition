using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHidePanels : MonoBehaviour {
    public CanvasGroup inventoryPanel;
    bool inventoryUp = false;
    public CanvasGroup pausePanel;
    bool pauseUp = false;
    CameraHandler cameraHandler;

    void Awake() {
        cameraHandler = GetComponent<CameraHandler>();
    }

    void Start () {
        TogglePanel(inventoryPanel, inventoryUp);
        TogglePanel(pausePanel, pauseUp);
    }

    void Update () {
        // inventory panel
        if(Input.GetKeyDown(KeyCode.I) && !pauseUp){
            inventoryUp = !inventoryUp;
            TogglePanel(inventoryPanel, inventoryUp);
        }

        // pause panel
        if(Input.GetButtonDown("Pause")){
            pauseUp = !pauseUp;
            TogglePanel(pausePanel, pauseUp);
            Time.timeScale = Convert.ToInt32(pauseUp);
        }
    }

    public void TogglePanel(CanvasGroup panel, bool show){
        panel.alpha = Convert.ToInt32(show);
        panel.interactable = show;
        panel.blocksRaycasts = show;

        if (inventoryUp || pauseUp) {
            cameraHandler.TurnOffPanAndZoom();
            
        } else {
            cameraHandler.TurnOnPanAndZoom();
        }
    }
}
