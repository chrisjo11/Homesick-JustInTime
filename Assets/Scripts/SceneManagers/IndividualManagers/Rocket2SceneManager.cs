using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket2SceneManager : MainManager
{
    private void Start()
    {
        checkPoint = 0;
        world = 7;
        Player.damageMultiplier = 1;
    }
    public NPC rob;
    public NPC tod;
    public NPC World;

    private void Update()
    {
        switch (checkPoint)
        {
            case 0:
                playScene0();
                break;
            case 1:
                SceneManager.LoadScene(world + 1);
                break;
        }
    }

    private void playScene0()
    {
        if (true) // Condition for the scene to begin
        {
            runScene(0); // run the scene
            if (Input.GetButtonDown("Skip"))
            {
                scenePos++;
            }
            switch (scenePos)
            {
                case 1:
                    World.say("back at the ship...");
                    break;
                case 2:
                    rob.say("this is the last time i'm going to say this:");
                    break;
                case 3:
                    rob.say("NO MORE TOUCHING BUTTONS");
                    break;
                case 4:
                    tod.say("*monching on hot pockets*");
                    break;
                case 5:
                    rob.say("you know what come over here i'll WARM those hot pockets up for you");
                    break;
                case 6:
                    World.say("*aggressive shuffling*");
                    break;
                case 7:
                    World.say("rob falls on the BIG RED button");
                    break;
                case 8:
                    World.say("*click*");
                    break;

                default:
                    finishScene(0);
                    break;
            }
        }
    }
}
