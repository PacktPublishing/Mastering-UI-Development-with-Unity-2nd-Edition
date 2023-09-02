using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    public List<Sprite> possibleSprites;
    SpriteRenderer imageComponent;

    void Awake(){
        imageComponent = GetComponent<SpriteRenderer>();
        imageComponent.sprite = possibleSprites[UnityEngine.Random.Range(0, possibleSprites.Count)];
    }
}
