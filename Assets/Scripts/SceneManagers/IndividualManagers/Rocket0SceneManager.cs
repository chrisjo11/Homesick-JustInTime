using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket0SceneManager : MainManager
{
    private void Start()
    {
        checkPoint = 0;
        world = 3;
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
                    rob.say("*floating*");
                    break;
                case 2:
                    tod.say("*floating*");
                    break;
                case 3:
                    rob.say("*floating*");
                    break;
                case 4:
                    tod.say("*floating*");
                    break;
                case 5:
                    World.say("*click*");
                    break;
                case 6:
                    rob.say("...");
                    break;
                case 7:
                    tod.say("...");
                    break;
                case 8:
                    rob.say("wait to-");
                    break;
                case 9:
                    rob.say("AAAHHHHHHH");
                    break;
                case 10:
                    World.say("*thump*");
                    break;
                case 11:
                    rob.say("*inhale*");
                    break;
                case 12:
                    rob.say("TOD!");
                    break;
                case 13:
                    tod.say("sup");
                    break;
                case 14:
                    rob.say("how many Homesick™s do we have to go through before you realize you DON'T PRESS BIG BUTTONS or better yet you DON’T PRESS ANY BUTTONS");
                    break;
                case 15:
                    tod.say("bro wdym im just tryna grab my hot pocket then the gravity turns on");
                    break;
                case 16:
                    World.say("...");
                    break;
                case 17:
                    tod.say("ohh you mean this big button");
                    break;
                case 18:
                    tod.say("don't worry rob bro i got this bro");
                    break;
                case 19:
                    World.say("*click*");
                    break;
                case 20:
                    rob.say("wait tod nonononononononono");
                    break;
                case 21:
                    World.say("*whoosh*");
                    break;
                case 22:
                    World.say("...");
                    break;
                case 23:
                    World.say("A little later...");
                    break;
                case 24:
                    World.say("...");
                    break;
                case 25:
                    rob.say("...");
                    break;
                case 26:
                    tod.say("dude bro we should use the time travel thing to go back to when hot pockets were invented so i can get the recipe");
                    break;
                case 27:
                    rob.say("tod we're literally trying to get BACK HOME, where you can just BUY hotpockets, even if we GOT the recipe you would make ME cook them and you would sit around and do NOTHING.");
                    break;
                case 28:
                    tod.say("bro these hot pockets are fire");
                    break;
                case 29:
                    rob.say("...");
                    break;
                case 30:
                    rob.say("i don't even care anymore just press the big red button already so that we can make it back to our timeline");
                    break;
                case 31:
                    tod.say("ok");
                    break;
                case 32:
                    tod.say("bruh it didn't do nothi-");
                    break;
                case 33:
                    rob.say("THE BIG RED BUTTON.");
                    break;
                case 34:
                    tod.say("ohhhh");
                    break;
                case 35:
                    World.say("*click*");
                    break;
                case 36:
                    World.say("*zap*");
                    break;

                default:
                    finishScene(0);
                    break;
            }
        }
    }
}
