using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TodMovement : MonoBehaviour
{
    private int speed = 20;

    public CharacterController2D controller; // Gets the movement controller

    public GameObject rob;
    public GameObject cam;
    public Rigidbody rb;

    void Start()
    {

    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (rob.transform.position.x >= -0.36 && transform.position.x > 15)
        {
            transform.position = new Vector3(4f, 20f, 0);
            
        }
    }
}
