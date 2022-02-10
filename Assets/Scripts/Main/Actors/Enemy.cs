using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    public int damage;
    public float speed;
    public int maxHealth;
    public string nametag;

    public GameObject lowBound;
    public GameObject highBound;

    private int direction = 1;
    private int health;
    private float lowX;
    private float highX;

    private void Start()
    {
        health = maxHealth;
        lowX = lowBound.transform.position.x;
        highX = highBound.transform.position.x;
    }

    private void FixedUpdate() // Called based on elapsed time.
    {
        if(canMove && canInput)
        {
            move();
        }
        checkDeath();
    }

    public void doDamage()
    {
        health--;
    }

    private void checkDeath()
    {
        if(health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void say(string script)
    {
        base.say(script, nametag);
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
