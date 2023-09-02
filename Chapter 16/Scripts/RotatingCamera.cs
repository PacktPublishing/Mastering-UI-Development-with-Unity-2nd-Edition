using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCamera : MonoBehaviour {
    public Transform target;
    public float speed;
    void Update () {
        // constant rotation
        //transform.RotateAround (target.transform.position, Vector3.up, speed * Time.deltaTime);
        
        //rotation with mouse
        if(Input.GetMouseButton(0)) {
            transform.RotateAround(target.transform.position,transform.up, -Input.GetAxis("Mouse X") * speed);
        } 
    }
}
