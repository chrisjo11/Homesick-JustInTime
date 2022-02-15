using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket3SceneManager : MainManager
{
    private void Start()
    {
        checkPoint = 0;
        world = 9;
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
                    tod.say("oh man... my hot pocket");
                    break;
                case 3:
                    rob.say("we almost died multiple times and all you care about is your hot pockets.");
                    break;
                case 4:
                    tod.say("bro...");
                    break;
                case 5:
                    rob.say("listen, when we get back home you can have all the hot pockets you want, you just have to cooperate for a little bit.");
                    break;
                case 6:
                    rob.say("now that we've finally got you off of those hot pockets, let's press the RIGHT button.");
                    break;
                case 7:
                    rob.say("this button should do the trick...");
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
