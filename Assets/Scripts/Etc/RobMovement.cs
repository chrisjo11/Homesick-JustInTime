using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobMovement : MonoBehaviour
{
    private float speed = 20;

    public CharacterController2D controller; // Gets the movement controller

    // SceneObjects
    public GameObject tod;
    public GameObject cam;

    private bool isSkipped = false;

    private void skipScene()
    {
        transform.position = new Vector3(3.13153124f, 3.03674603f, 0);
    }

    private void introScene()
    {
        if (transform.position.x <= -0.36f)
        {
            controller.Move(speed * Time.fixedDeltaTime, false, false);
        }
        if (tod.transform.position.y <= 3.1 && transform.position.x <= 3 && transform.position.x >= -0.1f && cam.transform.position.y >= 2.7)
        {
            controller.Move(speed / 1.05f * Time.fixedDeltaTime, false, false);
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
