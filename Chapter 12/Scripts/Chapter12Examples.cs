using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter12Examples : MonoBehaviour {
    public void ScrollbarWithoutParameter(){
        Debug.Log("changed");
    }

    public void ScrollbarWithParameter(float value){
        Debug.Log(value);
    }
    
    public void ScrollViewWithParameter(Vector2 value){
        Debug.Log(value);
    }

}
