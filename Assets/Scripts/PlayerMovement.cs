using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float playerRunSpeed = 40;
    bool isJumping;
    bool isCrouching;
    bool isGrounded;
    public GameObject player;
    public GameObject ground;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // Used to get input
    {
        // Get Horizontal Axis Movement
        horizontalMove = Input.GetAxisRaw("Horizontal") * playerRunSpeed;

        

        // Check for Jump/Crouch Input
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            isCrouching = true;
        }
    }

    private void FixedUpdate() // Use to apply input
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, isCrouching, isJumping);
        isJumping = false;
        isCrouching = false;
        Debug.Log("stuff");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            Debug.Log("is ground");
        }
        
    }
}
