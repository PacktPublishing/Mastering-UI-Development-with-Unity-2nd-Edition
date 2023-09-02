using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressMeters : MonoBehaviour {
    public uint health;
    [SerializeField] uint totalHealth;
    [SerializeField] float percentHealth;

    [SerializeField] RectTransform healthBar;
    [SerializeField] Image progressMeter;

    void Update() {
        //cap health
        if (health > totalHealth) {
            health = totalHealth;
        }

        //calculate health percentage
        percentHealth = (float)health / totalHealth;

        //horizontal health bar
        healthBar.localScale = new Vector2(percentHealth, 1f);

        //circular progress meter
        progressMeter.fillAmount = percentHealth;
    }
}