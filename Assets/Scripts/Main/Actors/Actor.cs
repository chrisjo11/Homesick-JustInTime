using System.Collections;
using UnityEngine;

public class Actor : MonoBehaviour
{
    protected bool isOnGround;
    public CharacterController2D controller; // Gets the movement controller

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
}
