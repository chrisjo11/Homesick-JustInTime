using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Player : Actor
{
    // Layermask References

    public LayerMask enemy; // enemy layermask
    public LayerMask collectable; // item layermask
    public LayerMask powerup; // powerup layermask
    public LayerMask objective; // objective layermask

    // Plate Manager Reference

    public PlateManager plateManager;

    // Player Animation Reference

    public Animator animator;

    // Player Booleans

    public bool isJumping; // Set to true if the player is jumping
    private bool tookDamage; // Set to true if the player just took damage

    // Player Static Vars

    private static int MAX_HEALTH = 20; // Sets the player's max health
    private static float playerRunSpeed = 60; // Sets the player's run speed
    public static bool isTod = false; // Set to true if the current player is Tod
    public static bool isAttacking = false; // Set to true if the player is currently attacking
    private static bool isInteracting = false;
    private static bool isMoving;
    public static int damageMultiplier = 1;
    private static bool isDebug = false;
    private static float i = 0f;

    // Player Input Vars

    private float horizontalMove; // Input scalar for horizontal movement

    // Powerup Vars

    public bool isJumpBoosted = false;
    private float powerupTimer = 10;

    // Player HUD

    private int health = MAX_HEALTH; // Player's current health
    public GameObject jumpGreen;
    public TextMeshProUGUI healthDisplay; // Player's health display

    // Two-player accesses

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
        powerupTimer-=Time.deltaTime;
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
        isAttacking = true;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, 3, enemy);
        foreach (Collider2D col in colliders)
        {
            col.gameObject.GetComponent<Enemy>().doDamage(1 * damageMultiplier);
        }
    }

    public void say(string script)
    {
        setToRob();
        base.say(script, "Rob", textcolor);
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

    private void updateHealthDisplay(int health) // Updates the player's current health display
    {
        if(health >= 0) healthDisplay.text = "Health: " + health;
    }

    private void checkInput() // Checks for Input
    {
        if (canMove && canInput) // If the player can move, check movement input
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * playerRunSpeed; // Set horizontal movement axis to the direction and magnitude of the horizontal input.

            if (Input.GetButtonDown("Jump"))
            {
                isJumping = true; // If a jump button is pressed, the player is jumping.
                animator.SetBool("jumping", true);
            }

            if (Input.GetButtonDown("Switch")) switchPlayer(); // If the switch button is pressed, the player switches.
        } 
        else // If the player cannot move, lock movement
        {
            horizontalMove = 0;
            isJumping = false;
        }
        
        if (canInput && Input.GetButtonDown("Attack")) attack();

        if (canInput && Input.GetButtonDown("Interact")) isInteracting = true; else isInteracting = false; 

        if(Input.GetButtonDown("Debug"))
        {
            isDebug = !isDebug;
        }
    }

    private void checkStatus() // Checks the player's status 
    {
        if(health <= 0) onLose(); // If the player's health is zero or lower, you lose.

        if (isJumpBoosted) resetJump();

        if (tookDamage) // Updates the heart display exactly once whenever the player takes damage
        {
            updateHealthDisplay(health);
            tookDamage = false;
        }

        if(checkWin())
        {
            onWin();
        }

        if (horizontalMove == 0) isMoving = false; else isMoving = true;

        if (isMoving)
        {
            animator.SetBool("moving", true);
        } else
        {
            animator.SetBool("moving", false);
        }

        if (isAttacking) animator.SetBool("attacking", true); else animator.SetBool("attacking", false);
        if(i - 0.35 >= 0 && isAttacking)
        {
            isAttacking = false;
            i = 0f;
        } else if(isAttacking)
        {
            Debug.Log(i);
            i += Time.deltaTime;
        }

        if (isDebug) deBug();
    }

    private void deBug()
    {
        health = -1;
    }

    public void OnLanding()
    {
        animator.SetBool("jumping", false);
        Debug.Log("landed");
    }

    private void updateStatus()
    {
        activateGreenOverlay();
    }

    private void OnCollisionEnter2D(Collision2D col) // Runs when the player collides with any other 2d Hitbox
    {
        if (col.gameObject.tag == "Ground") isOnGround = true; // If the GameObject is tagged Ground, the player is on the ground.

        if (col.gameObject.tag == "Orphan") // If the GameObject is tagged Orphan, the player loses 1 health, and took damage.
        {
            health-=col.gameObject.GetComponent<Enemy>().damage;
            onDamage();
        }

        if (col.gameObject.tag == "MegaOrphan") // If the GameObject is tagged MegaOrphan, the player immediately loses all health.
        {
            health = 0;
            onDamage();
        }

        if (col.gameObject.tag == "Plate")
        {
            onPlate(col.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D col) // Runs when this GameObject exits collision
    {
        if (col.gameObject.tag == "Ground") isOnGround = false; // If the GameObject is tagged Ground, the player is no longer on the ground.
    }

    private void onLose() // called when the player has 0 or less health.
    {
        if(isDebug)
        {
            Debug.Log("you lost");
        } else
        {
            SceneManager.LoadScene(12);
        }
    }

    private void onWin()
    {
        SceneManager.LoadScene(MainManager.world + 1);
    }

    private bool checkWin()
    {
        if(isInteracting)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, 2, objective);
            if(colliders.Length > 0)
            {
                return true;
            }
        }
        return false;
    }

    private void onDamage() // called when the player takes damage
    {
        tookDamage = true;
        ouch.Play();
    }

    private void onPlate(GameObject plate)
    {
        int index = -1;
        for(int i = 0; i < plateManager.plates.Length; i++)
        {
            if(plateManager.plates[i].Equals(plate))
            {
                if(!isTod)
                {
                    index = i;
                } else if (isTod) {
                    index = i/2;
                }
                
            }
        }

        if(isTod && plate.GetComponent<Plate>().isTod)
        {
            plateManager.doorStatuses[0][index] = true;
        } else if (!isTod && !plate.GetComponent<Plate>().isTod)
        {
            plateManager.doorStatuses[1][index] = true;
        }
    }

    private void Awake() // Called once the script initializes
    {
        updateHealthDisplay(health); // Initially update the player's health display

        activateGreenOverlay();
    }

    private void Start() // Called before the first frame update, after the script initializes
    {
        otherPlayer.transform.position = otherFacade.transform.position;
        thisFacade.transform.position = thisPlayer.transform.position;
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