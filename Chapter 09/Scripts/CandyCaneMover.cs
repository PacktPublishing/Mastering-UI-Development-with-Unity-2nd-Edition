using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyCaneMover : MonoBehaviour {
    private Transform candyCane;

    void Awake() {
        candyCane = GetComponent<Transform>();
    }

    public void MoveLeft() {
        candyCane.Translate(Vector3.left * 3f);
    }

    public void MoveRight() {
        candyCane.Translate(Vector3.right * 3f);
    }
}
