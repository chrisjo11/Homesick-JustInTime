using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Actor
{
    public string nametag;
    public Animator animator;

    public void say(string script)
    {
        base.say(script, nametag, textcolor);
    }
}