using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Actor : MonoBehaviour
{
    protected bool isOnGround;
    public static bool isSaying;
    public CharacterController2D controller; // Gets the movement controller
    public TextManager textManager;

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

    public void say(string message)
    {
        if (!isSaying)
        {
            textManager.displayMessage(message);
            isSaying = true;
        } else if (isSaying)
        {
            isSaying = false;
            textManager.destroyMessage();
        }
    }

    private void Update()
    {
        
    }
}
