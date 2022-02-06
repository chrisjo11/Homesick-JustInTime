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

    private static int MAX_HEALTH = 5;
    private static float playerRunSpeed = 50; // Sets the player's run speed

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

    // Two-player accesses

    public GameObject otherPlayer;
    public GameObject otherFacade;
    public GameObject thisPlayer;
    public GameObject thisFacade;

    private void switchPlayer()
    {
        otherPlayer.transform.position = otherFacade.transform.position;
        thisFacade.transform.position = thisPlayer.transform.position;
        otherPlayer.SetActive(true);
        otherFacade.SetActive(false);
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
        isInventoryOn = onStatus;
        canMove = !onStatus;

        inventoryDisplay.SetActive(onStatus);
    }

    private void updatehealthDisplay(int health)
    {
        if(health >= 0)
        {
            healthDisplay.text = "Health: " + health;
        }
    }

    private void checkInput() // Checks for Input
    {
        if (canMove) // If the player can move, sets horizontal movement vector to the horizontal input, if not, sets the horizontal movement vector to 0
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * playerRunSpeed;
        } else
        {
            horizontalMove = 0;
        }

        if (Input.GetButtonDown("Jump")) isJumping = true; // Sets jumping to true when jump input is checked

        if (Input.GetButtonDown("Inventory")) // Flips the inventory display from on/off the screen when inventory input is checked
        {
            if(!isInventoryOn)
            {
                displayInventory(true);
            } else
            {
                displayInventory(false);
            }
        }

        if (Input.GetButtonDown("Switch"))
        {
            switchPlayer();
        }
    }

    private void checkStatus() { // Checks the player's status
        if(health <= 0) Lose();

    }

    private void updateStatus()
    {
        if(tookDamage) // Updates the heart display whenever player takes damage
        {
            updatehealthDisplay(health);
            tookDamage = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col) // Runs when this GameObject collides
    {
        if (col.gameObject.tag == "Ground") isOnGround = true;
        if (col.gameObject.tag == "Orphan")
        {
            health--;
            tookDamage = true;
            Debug.Log("you lost health");
        }
        if (col.gameObject.tag == "MegaOrphan")
        {
            health = 0;
            tookDamage = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col) // Runs when this GameObject exits collision
    {
        if (col.gameObject.tag == "Ground") isOnGround = false;
    }

    private void Lose() // Lose is called when the player has 0 or less health.
    { 
        Debug.Log("lmao you're trash");
    }

    // Start is called before the first frame update
    private void Start()
    {
        displayInventory(false);
    }

    // Update is called once per frame
    private void Update() // Used to get input
    {
        // Check for inputs
        checkInput();

        // Check for statuses
        checkStatus();

        // Update statuses
        updateStatus();
    }

    private void FixedUpdate() // Use to apply input
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, isJumping);
        isJumping = false;
    }
}