using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : Actor
{
    // GameObject References

    public LayerMask enemy; // Enemy layermask
    public LayerMask collectable; // Item layermask
    public LayerMask powerup; // powerup layermask

    // Player Booleans

    private bool isJumping; // Set to true if the player is jumping
    private bool tookDamage; // Set to true if the player just took damage

    // Player Static Vars

    private static int MAX_HEALTH = 20; // Sets the player's max health
    private static float playerRunSpeed = 60; // Sets the player's run speed
    public static bool isTod = false; // Set to true if the current player is Tod
    public static bool isAttacking = false; // Set to true if the player is currently attacking
    private static bool isMoving; // Set to true if the player is currently moving
    public static int damageMultiplier = 1;

    // Player Input Vars

    private float horizontalMove; // Input scalar for horizontal movement

    // Player Inventory

    public GameObject inventoryDisplay; // The current player's inventory display
    private List<Collectable> inventory = new List<Collectable>(); // List of the player's aquired GameObjects
    private Collectable equippedItem; // The player's current equiped item
    private bool isInventoryOn; // Set to true if the player currently has their inventory on

    // Powerup Vars

    public bool isJumpBoosted = false;
    private int powerupTimer = (int) (6000*(60f/144f));

    // Player HUD

    private int health = MAX_HEALTH; // Player's current health
    public GameObject jumpGreen;
    public TextMeshProUGUI healthDisplay; // Player's health display

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

    public void activateGreenOverlay()
    {
        Debug.Log("running");
        if(isJumpBoosted)
        {
            jumpGreen.SetActive(true);
        } else
        {
            jumpGreen.SetActive(false);
        }
    }

    private void resetJump()
    {
        powerupTimer--;
        Debug.Log(powerupTimer);
        if(powerupTimer <= 0)
        {
            powerupTimer = (int)(6000 * (60f / 144f));
            isJumpBoosted = false;
            controller.increaseJumpForce(1100);
        }
    }

    private void getPowerups()
    {
        Collider2D[] colliders1 = Physics2D.OverlapCircleAll(gameObject.transform.position, 1, powerup);
        foreach (Collider2D collider in colliders1)
        {
            collider.gameObject.GetComponent<Powerup>().isActive = true;
        }
    }

    public void addHealth(int hearts)
    {
        health += hearts;
        tookDamage = true;
    }

    public void increaseJump(float amount)
    {
        controller.increaseJumpForce(amount);
    }

    private void attack()
    {
        if(false)
        {
            
        } else if(false)
        {

        }
        else
        {
            useHand();
        }
    }

    private void useHand()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, 3, enemy);
        foreach (Collider2D col in colliders)
        {
            Debug.Log(col);
            col.gameObject.GetComponent<Enemy>().doDamage(1 * damageMultiplier);
        }
    }

    public void say(string script)
    {
        setToRob();
        base.say(script, "Rob");
    }

    private void setToRob()
    {
        if (isTod)
        {
            switchPlayer();
        }
    }

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

        isTod = !isTod;
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
        if(health >= 0) healthDisplay.text = "Health: " + health;
    }

    private void checkInput() // Checks for Input
    {
        if (canMove && canInput) // If the player can move, check movement input
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
        

        /*if (canInput && Input.GetButtonDown("Inventory")) // Flips the inventory display from on/off the screen when inventory input is checked
        {
            if (!isInventoryOn) displayInventory(true);
            else displayInventory(false);
        }*/

        if (canInput && Input.GetButtonDown("Attack")) attack();
    }

    private void checkStatus() // Checks the player's status 
    {
        if(health <= 0) onLose(); // If the player's health is zero or lower, you lose.

        if (horizontalMove == 0) Player.isMoving = false;
        else Player.isMoving = true;

        if (isJumpBoosted) resetJump();
    }

    private void updateStatus()
    {
        if(tookDamage) // Updates the heart display exactly once whenever the player takes damage
        {
            updateHealthDisplay(health);
            tookDamage = false;
        }

        activateGreenOverlay();
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
        SceneManager.LoadScene(8);
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

        activateGreenOverlay();
    }

    private void Start() // Called before the first frame update, after the script initializes
    {
        
    }

    private void Update() // Called once per frame
    {
        checkInput(); // Check for inputs

        checkStatus(); // Check for statuses

        updateStatus(); // Update statuses

        getPowerups(); // Gets Powerups
    }

    private void FixedUpdate() // Runs based on elapsed time
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, isJumping);
        isJumping = false;
    }
}