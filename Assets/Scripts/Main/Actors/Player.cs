using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : Actor
{
    // Player Booleans

    private bool isJumping;
    private bool canMove;
    private bool tookDamage;

    // Player Static Vars

    private static int MAX_HEALTH = 20; // Sets the player's max health
    private static float playerRunSpeed = 60; // Sets the player's run speed

    // Player Input Vars

    private float horizontalMove;

    // Player Inventory

    public GameObject inventoryDisplay;
    private List<Collectable> inventory = new List<Collectable>(); // List of the player's aquired GameObjects
    private Collectable equippedItem;
    private bool isInventoryOn;

    // Player healthDisplay

    private int health = MAX_HEALTH;
    public TextMeshProUGUI healthDisplay;

    // Two-player tree accesses

    public GameObject otherPlayer;
    public GameObject otherFacade;
    public GameObject thisPlayer;
    public GameObject thisFacade;

    // Player Sounds
    public AudioSource ouch;
    public AudioSource speechNormal;
    public AudioSource speechAngry;
    public AudioSource speechHappy;

    private void switchPlayer() // Switches the current player
    {
        // Set positions equal
        otherPlayer.transform.position = otherFacade.transform.position;
        thisFacade.transform.position = thisPlayer.transform.position;

        // Activates the other player, inactivates the other player's facade
        otherPlayer.SetActive(true);
        otherFacade.SetActive(false);

        // Activates the current player's facade, inactivates the current player
        thisFacade.SetActive(true);
        thisPlayer.SetActive(false);
    }

    private void addToInventory(Collectable item) // Adds a given GameObject to a player's inventory
    { 
        inventory.Add(item);
    }

    private void equipItem(int index) // Equps an item from the players inventory given an integer index
    {
        equippedItem = inventory[index];
    }

    private void displayInventory(bool onStatus) // Displays the player's inventory
    {
        // Locks movement and inventory display
        isInventoryOn = onStatus;
        canMove = !onStatus;

        // Activates the player's inventory panel
        inventoryDisplay.SetActive(onStatus);
    }

    private void updateHealthDisplay(int health) // Updates the player's current health display
    {
        if(health >= 0)
        {
            healthDisplay.text = "Health: " + health;
        }
    }

    private void checkInput() // Checks for Input
    {
        if (canMove) // If the player can move, check movement input
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * playerRunSpeed; // Set horizontal movement axis to the direction and magnitude of the horizontal input.

            if (Input.GetButtonDown("Jump")) isJumping = true; // If a jump button is pressed, the player is jumping.

            if (Input.GetButtonDown("Switch")) switchPlayer(); // If the switch button is pressed, the player switches.
        } 
        else // If the player cannot move, lock movement
        {
            horizontalMove = 0;
            isJumping = false;
        }
        

        if (Input.GetButtonDown("Inventory")) // Flips the inventory display from on/off the screen when inventory input is checked
        {
            if(!isInventoryOn)
            {
                displayInventory(true);
            } 
            else
            {
                displayInventory(false);
            }
        }
    }

    private void checkStatus() // Checks the player's status 
    {
        if(health <= 0) onLose(); // If the player's health is zero or lower, you lose.
    }

    private void updateStatus()
    {
        if(tookDamage) // Updates the heart display exactly once whenever the player takes damage
        {
            updateHealthDisplay(health);
            tookDamage = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col) // Runs when the player collides with any other 2d Hitbox
    {
        if (col.gameObject.tag == "Ground") isOnGround = true; // If the GameObject is tagged Ground, the player is on the ground.

        if (col.gameObject.tag == "Orphan") // If the GameObject is tagged Orphan, the player loses 1 health, and took damage.
        {
            health--;
            onDamage();
        }

        if (col.gameObject.tag == "MegaOrphan")// If the GameObject is tagged MegaOrphan, the player immediately loses all health.
        {
            health = 0;
            onDamage();
        }
    }

    private void OnCollisionExit2D(Collision2D col) // Runs when this GameObject exits collision
    {
        if (col.gameObject.tag == "Ground") isOnGround = false; // If the GameObject is tagged Ground, the player is no longer on the ground.
    }

    private void onLose() // called when the player has 0 or less health.
    { 
        Debug.Log("lmao you're trash");
    }

    private void onDamage() // called when the player takes damage
    {
        tookDamage = true;
        ouch.Play();
    }

    private void Awake() // Called once the script initializes
    {
        displayInventory(false); // Initialize the player's inventory as inactive

        updateHealthDisplay(health); // Initially update the player's health display
    }

    private void Start() // Called before the first frame update
    {
        
    }

    private void Update() // Called once per frame
    {
        checkInput(); // Check for inputs

        checkStatus(); // Check for statuses

        updateStatus(); // Update statuses
    }

    private void FixedUpdate() // Runs based on elapsed time
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, isJumping);
        isJumping = false;
    }
}