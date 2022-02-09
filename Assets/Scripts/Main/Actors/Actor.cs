using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Actor : MonoBehaviour
{
    protected bool isOnGround;
    protected bool canMove = true;
    protected static bool canInput = true;

    public static bool isSaying;
    public CharacterController2D controller; // Gets the movement controller
    protected static TextManager textManager;

    private void Start()
    {
        textManager = GameObject.FindGameObjectWithTag("TextManager").GetComponent<TextManager>();
        canMove = true;
        canInput = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground") // Check if touching the ground
        {
            isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground") // Check if leaving the ground
        {
            isOnGround = false;
        }
    }

    public static void startSaying()
    {
        isSaying = true;
        canInput = false;
    }

    public static void stopSaying()
    {
        isSaying = false;
        canInput = true;
        textManager.destroyMessage();
    }

    protected void say(string script, string tag)
    {
        if(!isSaying)
        {
            startSaying();
        }
        textManager.displayMessage(tag + ": " + script);
    }

    private void Update()
    {
        
    }
}