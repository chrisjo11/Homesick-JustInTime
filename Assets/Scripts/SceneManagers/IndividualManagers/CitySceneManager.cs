using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitySceneManager : MainManager
{
    public void Start()
    {
        world = 8; // Change to the index of the current world
        checkPoint = 0;
    }

    // World actor
    public NPC World;

    // Players in Scene
    public Player rob;
    public Player tod;
    public NPC todFacade; // Tod's facade is technically an NPC, but it is still a player that is in the scene.

    // NPCs in scene
    public NPC mime;

    private void Update()
    {
        Debug.Log(checkPoint);
        Debug.Log(rob.transform.position.x);
        switch (checkPoint)
        {
            case 0:
                playScene0();
                break;
            case 1:
                playScene1();
                break;
            case 2:
                playScene2();
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
                    rob.say("...");
                    break;
                case 2:
                    todFacade.say("ayo wtf");
                    break;
                case 3:
                    rob.say("shut up... where are we?");
                    break;
                case 4:
                    todFacade.say("a city");
                    break;
                case 5:
                    rob.say("...");
                    break;
                case 6:
                    todFacade.say("rob do you think there's a micro-");
                    break;
                case 7:
                    rob.say("we’re missing whole sheets of metal from our spaceship and my partner only cares about his damn hot pockets");
                    break;
                case 8:
                    todFacade.say("bro i'm just hungry");
                    break;
                case 9:
                    rob.say("...");
                    break;
                case 10:
                    todFacade.say("let's find a microwave.");
                    break;
                case 11:
                    World.say("go find a (microwave) metal sheet");
                    break;
                default:
                    finishScene(0); // finishes the scene
                    break;
            }
        }
    }

    private void playScene1() // Replace 0 with the scene number
    {
        if (rob.gameObject.transform.position.x > 35) // Replace true with the condition that you need for the scene to play
        {
            runScene(1); // Replace 1 with the scene number
            if (Input.GetButtonDown("Skip"))
            {
                scenePos++;
            }
            switch (scenePos)
            {
                case 1: // Add more cases for each person saying something
                    rob.transform.position = new Vector3(36.5f, rob.transform.position.y, rob.transform.position.z);
                    todFacade.transform.position = new Vector3(34.5f, rob.transform.position.y, tod.transform.position.z);
                    rob.say("..."); // Say the dialogue
                    break;
                case 2:
                    mime.say("*pompous hand signals*");
                    break;
                case 3:
                    rob.say("???");
                    break;
                case 4:
                    todFacade.say("...");
                    break;
                case 5:
                    mime.say("*lightly exaggerated hand signals*");
                    break;
                case 6:
                    rob.say("do we... kill it?");
                    break;
                case 7:
                    mime.say("*VERY OVERLY EXAGGERATED HAND SIGNALS*");
                    break;
                case 8:
                    todFacade.say("alr bro you don't have to bring bobette into this");
                    break;
                case 9:
                    todFacade.say("we got you bro, we'll leave");
                    break;
                case 10:
                    World.say("go find something for your rocket's hull down the city");
                    break;

                default:
                    finishScene(1); // Replace 1 with the scene number
                    break;
            }
        }
    }
    private void playScene2() // Replace 0 with the scene number
    {
        if (rob.gameObject.transform.position.x > 240) // Replace true with the condition that you need for the scene to play
        {
            runScene(2); // Replace 1 with the scene number
            if (Input.GetButtonDown("Skip"))
            {
                scenePos++;
            }
            switch (scenePos)
            {
                case 1:
                    rob.transform.position = new Vector3(241, rob.transform.position.y, rob.transform.position.z);
                    todFacade.transform.position = new Vector3(244, rob.transform.position.y, rob.transform.position.z);
                    rob.say("...");
                    break;
                case 2:
                    todFacade.say("bro i think i found something");
                    break;
                case 3:
                    rob.say("Tod that's a rock.");
                    break;
                case 4:
                    todFacade.say("oh");
                    break;
                case 5:
                    rob.say("...");
                    break;
                case 6:
                    rob.say("stop fooling around we have a home to get bac-");
                    break;
                case 7:
                    todFacade.say("wait bro dude if theres metal on the buildings why dont we just like borrow some bro");
                    break;
                case 8:
                    todFacade.say("yknow, for the rocket and stuff");
                    break;
                case 9:
                    rob.say("...");
                    break;
                case 10:
                    todFacade.say("or we can just use the roc-");
                    break;
                case 11:
                    rob.say("i don't care anymore let's just get some metal and go back to the rocket.");
                    break;

                default:
                    finishScene(2); // Replace 1 with the scene number
                    break;
            }
        }
    }
}
