using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionReferenceBasicCharacterController : MonoBehaviour
{
    private Rigidbody2D catRigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    private bool grounded;
    private Vector2 moveVector = new Vector2();

    [SerializeField] private InputActionAsset actions;
    private InputAction playerMoveAction;
    
    void Awake()
    {
        catRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        actions.FindActionMap("Player").Enable();
        actions.FindActionMap("Player").FindAction("Jump").performed += OnJump; // subscribe to the "Jump" action
        playerMoveAction = actions.FindActionMap("Player").FindAction("Move"); // find the "Move" action 
    }

    void Update() {
        moveVector = playerMoveAction.ReadValue<Vector2>();
        catRigidbody.velocity = new Vector2(speed * moveVector.x, catRigidbody.velocity.y);
    }
    
    // called from Jump Event on Cat's Player Input component
    public void OnJump(InputAction.CallbackContext context) {
        if(grounded){
            catRigidbody.AddForce(new Vector2(catRigidbody.velocity.x, jumpHeight));
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        grounded = true;
    }

    private void OnCollisionExit2D(Collision2D other) {
        grounded = false;
    }

    private void OnDisable() {
        actions.FindActionMap("Player").FindAction("Jump").performed -= OnJump;
        actions.FindActionMap("Player").Disable();
    }
}
