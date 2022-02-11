using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Powerup
{
    override
    public void onActive()
    {
        if(Player.isTod)
        {
            tod.addHealth(5);
        } else
        {
            rob.addHealth(5);
        }
        gameObject.SetActive(false);
    }
}
