using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMultiplier : Powerup
{
    override
    public void onActive()
    {
        Player.damageMultiplier++;
        gameObject.SetActive(false);
    }
}
