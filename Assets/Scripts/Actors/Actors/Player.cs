using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    // Player Booleans

    private bool isJumping;

    // Player Input Vars

    private float horizontalMove;

    // Player Character Controller

    public CharacterController2D controller;

    // Player Static Variables

    private static float playerRunSpeed = 50;

    void checkInput() // Checks for Input
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * playerRunSpeed; // Set Horizontal Input

        if (Input.GetButtonDown("Jump")) // Check for Jump Input
        {
            isJumping = true;
        }
    }

    void changeAnimation()
    {
        if(isJumping)
        {
            
        }
        else if(horizontalMove > 0)
        {

        } else if(horizontalMove < 0)
        {

        } else
        {

        }
    }

    void OnCollisionEnter2D(Collision2D col) // Runs when this GameObject collides
    {
        if (col.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col) // Runs when this GameObject exits collision
    {
        if (col.gameObject.tag == "Ground")
        {
            isOnGround = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() // Used to get input
    {
        // Check for input
        checkInput();

    }

    void FixedUpdate() // Use to apply input
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, isJumping);
        isJumping = false;
        Debug.Log(isOnGround);
    }
}