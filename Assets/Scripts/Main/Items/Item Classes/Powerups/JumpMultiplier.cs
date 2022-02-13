using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMultiplier : Powerup
{
    override
    public void onActive()
    {
        if (Player.isTod)
        {
            tod.increaseJump(1700);
            tod.isJumpBoosted = true;
        }
        else
        {
            rob.increaseJump(1700);
            rob.isJumpBoosted = true;
        }
        gameObject.SetActive(false);
    }
}
