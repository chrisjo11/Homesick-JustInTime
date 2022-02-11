using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : Item
{
    public abstract void onActive();
    private void Update()
    {
        if (isActive)
        {
            onActive();
        }
    }

    public string name;
    public bool isActive = false;
}
