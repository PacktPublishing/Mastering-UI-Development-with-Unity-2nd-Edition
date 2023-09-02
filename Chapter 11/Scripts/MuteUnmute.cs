using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteUnmute : MonoBehaviour {
    [SerializeField] Button musicButton;
    private Image musicImage;
    [SerializeField] private Sprite[] musicSprites = new Sprite[2];
    private bool musicOn = true;
    
    [SerializeField] Button soundButton;
    private Image soundImage;
    [SerializeField] private Sprite[] soundSprites = new Sprite[2];
    private bool soundOn = true;

    void Awake() {
        musicImage = musicButton.GetComponent<Image>();
        soundImage = soundButton.GetComponent<Image>();
    }

    public void ToggleMusic() {
        musicOn = !musicOn;
        musicImage.sprite = musicSprites[Convert.ToInt32(musicOn)];
    }

    public void ToggleSound() {
        soundOn = !soundOn;
        soundImage.sprite = soundSprites[Convert.ToInt32(soundOn)];
    }
}
