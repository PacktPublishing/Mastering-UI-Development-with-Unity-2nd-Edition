using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerBasicCharacterController : MonoBehaviour
{
    private Rigidbody2D catRigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    private float movement;
    private bool grounded;

    void Awake()
    {
        catRigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update() {
        movement = Input.GetAxis("Horizontal");
        catRigidbody.velocity = new Vector2(speed * movement, catRigidbody.velocity.y);
        
        if(grounded && Input.GetButtonDown("Jump")){
            catRigidbody.AddForce(new Vector2(catRigidbody.velocity.x, jumpHeight));
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        grounded = true;
    }

    private void OnCollisionExit2D(Collision2D other) {
        grounded = false;
    }
}
