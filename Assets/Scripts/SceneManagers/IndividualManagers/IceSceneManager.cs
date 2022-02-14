using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSceneManager : MainManager
{
    public void Start()
    {
        world = 6; // Change to the index of the current world
        checkPoint = 0;
    }

    // World actor
    public NPC World;

    // Players in Scene
    public Player rob;
    public Player tod;
    public NPC todFacade; // Tod's facade is technically an NPC, but it is still a player that is in the scene.

    // NPCs in scene
    public NPC yeti;

    private void Update()
    {
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
            case 3:
                playScene3();
                break;
        }
        Debug.Log(checkPoint);
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
                    todFacade.say("bro my hot pock-");
                    break;
                case 3:
                    rob.say("SHUT UP");
                    break;
                case 4:
                    rob.say("We’re missing our steering wheel, and should search around for any clues");
                    break;
                case 5:
                    World.say("Look for clues");
                    break;

                default:
                    finishScene(0); // finishes the scene
                    break;
            }
        }
    }

    private void playScene1() // Replace 0 with the scene number
    {
        if (rob.gameObject.transform.position.x > 11) // Replace true with the condition that you need for the scene to play
        {
            runScene(1); // Replace 1 with the scene number
            if (Input.GetButtonDown("Skip"))
            {
                scenePos++;
            }
            switch (scenePos)
            {
                case 1: // Add more cases for each person saying something
                    rob.transform.position = new Vector3(12, rob.transform.position.y, 0);
                    todFacade.transform.position = new Vector3(10, tod.transform.position.y, 0);
                    rob.say("...");
                    break;
                case 2:
                    todFacade.say("ayo watch out for that big snow dude over there bro");
                    break;
                case 3:
                    rob.say("What? Do you understand yeti language too? Of course you don-");
                    break;
                case 4:
                    todFacade.say("yeah");
                    break;
                case 5:
                    yeti.say("ℸ ̣ ⍑ᔑℸ ̣  ꖌ╎↸ ╎リ ℸ ̣ ⍑ᒷ ╎ᓵᒷ ⍑ᔑᓭ ℸ ̣ ⍑ᒷ steering ∴⍑ᒷᒷꖎ");
                    break;
                case 6:
                    todFacade.say("ok");
                    break;
                case 7:
                    World.say("go find the kid stuck in the ice");
                    break;

                default:
                    finishScene(1); // Replace 1 with the scene number
                    break;
            }
        }
    }
    private void playScene2() // Replace 0 with the scene number
    {
        if (rob.gameObject.transform.position.x > 135) // Replace true with the condition that you need for the scene to play
        {
            runScene(2); // Replace 1 with the scene number
            if (Input.GetButtonDown("Skip"))
            {
                scenePos++;
            }
            switch (scenePos)
            {
                case 1:
                    todFacade.transform.position = new Vector3(130, rob.transform.position.y+3, 0);
                    rob.transform.position = new Vector3(136, rob.transform.position.y, 0);
                    rob.say("Is that… a human hand… stuck in the ice?");
                    break;
                case 2:
                    todFacade.say("yo bro you think this kid coulda left a steering wheel in the ice");
                    break;
                case 3:
                    todFacade.say("like idk maybe he was playing with it and just left it or somn");
                    break;
                case 4:
                    rob.say("Tod, you're an idiot");
                    break;
                case 5:
                    todFacade.say("bro wtf");
                    break;
                case 6:
                    World.say("Find a steering wheel, or something.");
                    break;

                default:
                    finishScene(2); // Replace 1 with the scene number
                    break;
            }
        }
    }

    private void playScene3() // Replace 0 with the scene number
    {
        Debug.Log(rob.gameObject.transform.position.x);
        if (rob.gameObject.transform.position.x > 212) // Replace true with the condition that you need for the scene to play
        {
            runScene(3); // Replace 1 with the scene number
            if (Input.GetButtonDown("Skip"))
            {
                scenePos++;
            }
            switch (scenePos)
            {
                case 1:
                    todFacade.transform.position = new Vector3(211, rob.transform.position.y + 2, 0);
                    rob.transform.position = new Vector3(213, rob.transform.position.y, 0);
                    rob.say("is that-");
                    break;
                case 2:
                    todFacade.say("bro bro bro bro");
                    break;
                case 3:
                    todFacade.say("you won't believe this");
                    break;
                case 4:
                    todFacade.say("the kid really did leave behind a steering wheel");
                    break;
                case 5:
                    rob.say("I don't even care anymore lets just go back to the ship.");
                    break;
                case 6:
                    World.say("Pick up the steering wheel and go back to the ship.");
                    break;

                default:
                    finishScene(3); // Replace 1 with the scene number
                    break;
            }
        }
    }
}
