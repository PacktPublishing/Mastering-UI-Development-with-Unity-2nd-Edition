using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputBasicCharacterController : MonoBehaviour
{
    private Rigidbody2D catRigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    private bool grounded;
    private Vector2 moveVector = new Vector2();

    void Awake()
    {
        catRigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update() {
        catRigidbody.velocity = new Vector2(speed * moveVector.x, catRigidbody.velocity.y);
    }
    
    // called from Jump Event on Cat's Player Input component
    public void OnJump(InputAction.CallbackContext context) {
        if(grounded){
            catRigidbody.AddForce(new Vector2(catRigidbody.velocity.x, jumpHeight));
        }
    }

    // called from Move Event on Cat's Player Input component
    public void OnMove(InputAction.CallbackContext context) {
        moveVector = context.ReadValue<Vector2>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        grounded = true;
    }

    private void OnCollisionExit2D(Collision2D other) {
        grounded = false;
    }
}
