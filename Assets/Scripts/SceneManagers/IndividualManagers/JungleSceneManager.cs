using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleSceneManager : MainManager
{
    public void Start()
    {
        world = 4; // Change to the index of the current world
        checkPoint = 0;
        blackScreen.SetActive(false);
    }

    // World actor
    public NPC World;

    // Players in Scene
    public Player rob;
    public Player tod;
    public NPC todFacade; // Tod's facade is technically an NPC, but it is still a player that is in the scene.
    
    // Enemies in scene
    public Enemy enemy;

    // Black Screens
    public GameObject blackScreen;

    // Objective
    public GameObject francide;

    // NPCs in scene
    public NPC toucan;

    private void Update()
    {
        switch(checkPoint)
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
        if(true) // Condition for the scene to begin
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
                    todFacade.say("...");
                    break;

                case 3:
                    rob.say("...");
                    break;
                case 4:
                    todFacade.say("rob ngl");
                    break;
                case 5:
                    rob.say("ARE YOU KIDDING ME I SAID THE BIG RED BUTTON THERE WAS ONLY ONE BIG RED BUTTON ON THE ENTIRE SHIP HOW COULD YOU EVEN MISS IT I LITERALLY-");
                    break;
                case 6:
                    todFacade.say("oh damn my bad");
                    break;
                case 7:
                    rob.say("TOD, the ship’s fuel tank is leaking Fr-7. How the hell are we gonna get home now? And I swear to god if you say anything about your god-");
                    break;
                case 8:
                    todFacade.say("NOOOO DUDE BRO IF WE HAVE NO FUEL I CAN’T HEAT MY HOT POCKETS");
                    break;
                case 9:
                    rob.say("I will kill you");
                    break;
                case 10:
                    World.say("go east to find green.");
                    break;
                default:
                    finishScene(0); // finishes the scene
                    break;
            }
        }
    }

    private void playScene1() // Replace 0 with the scene number
    {
        if(rob.gameObject.transform.position.x > 2.8) // Replace true with the condition that you need for the scene to play
        {
            runScene(1); // Replace 1 with the scene number
            if (Input.GetButtonDown("Skip"))
            {
                scenePos++;
            }
            switch (scenePos)
            {
                case 1: // Add more cases for each person saying something
                    todFacade.gameObject.transform.position = new Vector3(1.8f, todFacade.transform.position.y, 0);
                    rob.gameObject.transform.position = new Vector3(2.9f, rob.transform.position.y, 0);
                    rob.say("ok Tod, we're gonna have to find that francide somewhere, or we're gonna be stuck here."); // Say the dialogue
                    break;
                case 2:
                    rob.say("we should probably go up to that toucan over there");
                    break;
                case 3:
                    rob.say("hey, do you speak engli-");
                    break;
                case 4:
                    toucan.say(".... . .-.. .-.. --- / .. / .- -- / - --- ..- -.-. .- -. / .. / .- -- / .- / ..-. .-. .. . -. -.. .-.. -.-- .-.-.- / - .... . / .-. --- -... / .- -. -.. / - .... . / - --- -.. / --. --- / - --- / . .- ... - / - --- / ..-. .. -. -.. / --. .-. . . -. .-.-.-");
                    break;
                case 5:
                    rob.say("wha-");
                    break;
                case 6:
                    todFacade.say("got you bro");
                    break;
                case 7:
                    World.say("go east to find green");
                    break;
                default:
                    finishScene(1); // Replace 1 with the scene number
                    break;
            }
        }
    }
    private void playScene2() // Replace 0 with the scene number
    {
        if (rob.gameObject.transform.position.x > 248) // Replace true with the condition that you need for the scene to play
        {
            runScene(2); // Replace 1 with the scene number
            if (Input.GetButtonDown("Skip"))
            {
                scenePos++;
            }
            switch (scenePos)
            {
                case 1:
                    todFacade.gameObject.transform.position = new Vector3(247f, 1, 0);
                    rob.gameObject.transform.position = new Vector3(251, 1, 0);
                    rob.say("ok tod there's the cave, now we just gotta go-"); // Say the dialogue
                    Debug.Log("ScenePos");
                    break;
                case 2:
                    todFacade.say("you good bro?");
                    break;
                case 3:
                    rob.say("h-how about you g-go into the cave and find the f-f-francide?");
                    break;
                case 4:
                    todFacade.say("bet");
                    break;
                case 5:
                    blackScreen.SetActive(true);
                    break;
                case 6:
                    blackScreen.SetActive(false);
                    break;
                case 7:
                    todFacade.gameObject.transform.position = new Vector3(255f, 0f, 0);
                    francide.gameObject.transform.position = new Vector3(260f, 0f, 0);
                    todFacade.say("i got the francide");
                    break;
                case 8:
                    todFacade.say("those cave trolls were not playing bro");
                    break;
                case 9:
                    todFacade.say("got the fuel tho");
                    break;
                case 10:
                    rob.say("alright, let's go back to the ship with the francide");
                    break;

                default:
                    finishScene(2); // Replace 1 with the scene number
                    break;
            }
        }
    }
}
