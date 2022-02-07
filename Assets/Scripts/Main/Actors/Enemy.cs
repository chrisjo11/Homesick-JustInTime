using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    public int damage;
    public float speed;
    public int maxHealth;

    public GameObject lowBound;
    public GameObject highBound;

    private int direction = 1;
    private float lowX;
    private float highX;

    private void Start()
    {
        lowX = lowBound.transform.position.x;
        highX = highBound.transform.position.x;
    }

    private void FixedUpdate() // Called based on elapsed time.
    {
        move();
    }

    private void move() // Moves the enemy back and forth through a low bound and high bound
    {
        if(transform.position.x >= highX)
        {
            direction = -1;
        } else if (transform.position.x <= lowX)
        {
            direction = 1;
        }
        Debug.Log(speed * direction);
        controller.Move(speed * direction * Time.deltaTime, false, false);

    }

}
