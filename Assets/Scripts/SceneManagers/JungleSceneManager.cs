using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleSceneManager : MonoBehaviour
{
    // Amount of Scenes

    private static readonly int SCENE_AMOUNT = 3;

    // Actors in Scenes

    public Player rob;
    public NPC todFacade;
    public Enemy enemy;

    // Scene Variables

    private static bool[] Scenes = new bool[SCENE_AMOUNT];
    private static int scenePos = 1;

    private void finishScene(int scene)
    {
        Actor.stopSaying();
        scenePos = 1; // Resets the scene position to 1
        Scenes[scene] = true;
    }

    private void runScene(int scene)
    {
        Actor.startSaying();
    }

    private void Update()
    {
        if(!Scenes[0])
        {
            playScene0();
        } else if(!Scenes[1])
        {
            playScene1();
        }
    }

    private void playScene0()
    {
        if(rob.gameObject.transform.position.x > 25) // Condition for the scene to begin
        {
            runScene(0); // run the scene
            if (Input.GetButtonDown("Skip"))
            {
                scenePos++;
            }
            switch (scenePos)
            {
                case 1:
                    rob.say("this works");
                    break;

                case 2:
                    rob.say("this also works");
                    break;

                case 3:
                    todFacade.say("yo im tod");
                    break;

                default:
                    finishScene(0); // finishes the scene
                    break;
            }
        }
    }

    private void playScene1() // Replace 0 with the scene number
    {
        if(rob.gameObject.transform.position.x > 40) // Replace true with the condition that you need for the scene to play
        {
            //Debug.Log("bruh");
            runScene(1); // Replace 0 with the scene number
            if (Input.GetButtonDown("Skip"))
            {
                scenePos++;
            }
            switch (scenePos)
            {
                case 1:
                    Debug.Log("bruhhhh");
                    rob.say("bruh");
                    break;

                default:
                    finishScene(1); // finishes the scene // Replace 0 with the scene number
                    break;
            }
        }
    }
}
