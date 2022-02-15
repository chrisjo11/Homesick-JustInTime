using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket1SceneManager : MainManager
{
    private void Start()
    {
        checkPoint = 0;
        world = 5;
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
        Debug.Log("yes");
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
                    rob.say("ok tod you have to chil don't press any more buttons");
                    break;
                case 3:
                    tod.say("ok let me just turn on the grav again i gotta use the bathroom");
                    break;
                case 4:
                    rob.say("ok just make sure you press the righ-");
                    break;
                case 5:
                    World.say("*click*");
                    break;

                default:
                    finishScene(0);
                    break;
            }
        }
    }
}
