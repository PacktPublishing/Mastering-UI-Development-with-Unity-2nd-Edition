using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMaker : MonoBehaviour {
    public GameObject tilePrefab;
    public int totalTiles;
    public int columnCount;
    public int rowCount;

    void Awake() {
	    PlaceTheTiles();
    }

    private void PlaceTheTiles(){
        float initialX = 0;
		//even columns
		if(columnCount % 2 == 0){
			initialX = -(columnCount / 2) + 0.5f;

		//odd columns
		}else{
			initialX = -(columnCount / 2);
		}

		float initialY = 0;
		//even rows
		if(rowCount % 2 == 0){
			//Debug.Log("even rows");
			initialY = rowCount / 2 - 0.5f;
		//odd rows
		}else{
			//Debug.Log("odd rows");
			initialY = rowCount / 2;
		}

		for(var i = 0; i < totalTiles; i++){
			Vector2 tileLocation = new Vector2(initialX + (i % columnCount), initialY - (i / columnCount));
			var theTile = Instantiate(tilePrefab, tileLocation, Quaternion.identity);
            theTile.transform.parent = transform;
		}
    }
}
