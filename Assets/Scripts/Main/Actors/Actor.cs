using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Actor : MonoBehaviour
{
    protected bool isOnGround;
    protected bool canMove = true;
    protected static bool canInput = true;

    private static bool stoppedSaying = true;

    public static bool isSaying;
    public CharacterController2D controller; // Gets the movement controller
    public TextManager textManager;
    public GameObject textScreen;

    private void Start()
    {
        canMove = true;
        canInput = true;
        textScreen.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(stoppedSaying)
        {
            textScreen.gameObject.SetActive(false);
        } else
        {
            textScreen.gameObject.SetActive(true);
        }
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
        stoppedSaying = false;
    }

    public static void stopSaying()
    {
        isSaying = false;
        canInput = true;
        stoppedSaying = true;
    }

    protected void say(string script, string tag)
    {
        stoppedSaying = false;
        if(!isSaying)
        {
            startSaying();
        }
        textManager.displayMessage(tag + ": " + script);
    }
}