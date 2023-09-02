using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour {
	public GameObject dragItem;
	public Canvas dragCanvas;

	public void StartDrag(GameObject selectedObject){
		dragItem = Instantiate(selectedObject, Input.mousePosition, selectedObject.transform.rotation) as GameObject;
		dragItem.transform.SetParent(dragCanvas.transform);
		dragItem.GetComponent<Image>().SetNativeSize();
		dragItem.transform.localScale = 1.1f * dragItem.transform.localScale;
		dragItem.GetComponent<Image>().raycastTarget = false;
	}

	public void Drag(){
		dragItem.transform.position = Input.mousePosition;
	}

	public void StopDrag(){
		Destroy(dragItem);
	}

	public void Drop(Image dropSlot){
		GameObject droppedItem = dragCanvas.transform.GetChild(0).gameObject;
		dropSlot.sprite = droppedItem.GetComponent<Image>().sprite;
	}

}

