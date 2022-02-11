using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TodMovement : MonoBehaviour
{
    public CharacterController2D controller; // Gets the movement controller

    public GameObject rob;
    public GameObject cam;

    private bool isSkipped = false;

    private void skipScene()
    {
        transform.position = new Vector3(4.24376392f, 3.03472495f, 0);
    }

    void introScene()
    {
        if (rob.transform.position.x >= -0.36 && transform.position.x > 15)
        {
            transform.position = new Vector3(4f, 20f, 0);

        }
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Skip"))
        {
            isSkipped = true;
        }
        if (!isSkipped)
        {
            introScene();
        }
        else
        {
            skipScene();
        }
    }
}
