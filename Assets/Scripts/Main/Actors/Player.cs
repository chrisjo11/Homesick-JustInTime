using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    // Player Booleans

    private bool isJumping;
    private bool hasLost;

    // Player Number Vars
    
    private int health = 20;
    private bool losthealth = false;

    // Player Input Vars

    private float horizontalMove;

    // Player Inventory

    private List<GameObject> inventory = new List<GameObject>(); // List of the player's auired GameObjects

    // Player Character Controller

    public CharacterController2D controller; // Gets the movement controller

    // Player Static Variables

    private static float playerRunSpeed = 50; // Sets the player's run speed

    void addToInventory(GameObject item) { // Adds a given GameObject to a player
        if(!(item.gameObject.tag == "collectable")) {
            Debug.Log("wtf");
        }
        inventory.Add(item);
    }

    void checkInput() // Checks for Input
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * playerRunSpeed; // Set Horizontal Input

        if (Input.GetButtonDown("Jump")) // Check for Jump Input
        {
            isJumping = true;
        }
    }

    void checkStatus() { // Checks the player's status
        if(health <= 0) {
            Lose();
        }
    }

    void OnCollisionEnter2D(Collision2D col) // Runs when this GameObject collides
    {
        if (col.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
        if (col.gameObject.tag == "Orphan") {
            health--;
        }
    }

    void OnCollisionExit2D(Collision2D col) // Runs when this GameObject exits collision
    {
        if (col.gameObject.tag == "Ground")
        {
            isOnGround = false;
        }
    }

    void Lose() { // Lose is called when the player has 0 or less health.
        Debug.Log("lmao you're trash");
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

        // Check for status
        checkStatus();

        Debug.Log(losthealth);

    }

    void FixedUpdate() // Use to apply input
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, isJumping);
        isJumping = false;
        Debug.Log(isOnGround);
    }
}