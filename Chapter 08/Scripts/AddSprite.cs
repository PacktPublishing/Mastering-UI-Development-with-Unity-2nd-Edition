using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSprite : MonoBehaviour {
	Image theImage;
	public Sprite theSprite;

	void Awake() {
		theImage = GetComponent<Image>();
	}

	void Start () {
		theImage.sprite = theSprite;
		theImage.preserveAspect = true;
	}
}