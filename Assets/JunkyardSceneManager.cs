using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JunkyardSceneManager : MainManager
{
    public void Start()
    {
        world = 10; // Change to the index of the current world
        checkPoint = 0;
    }

    // World actor
    public NPC World;

    // Players in Scene
    public Player rob;
    public Player tod;
    public NPC todFacade; // Tod's facade is technically an NPC, but it is still a player that is in the scene.
    public AudioSource song1;
    public AudioSource song2;

    // Camera
    public Camera cam;

    // TextUI

    public GameObject textUI;
    public GameObject textUI2;

    // timer

    private float timer = 0;

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
                    rob.say("that... didn't work?");
                    break;
                case 3:
                    todFacade.say("our engine is busted");
                    break;
                case 4:
                    rob.say("let's just try to find the engine.");
                    break;
                default:
                    finishScene(0);
                    break;
            }
        }
    }

    private void playScene1() // Replace 0 with the scene number
    {
        if (rob.gameObject.transform.position.x > 72) // Replace true with the condition that you need for the scene to play
        {
            runScene(1); // Replace 1 with the scene number
            if (Input.GetButtonDown("Skip"))
            {
                scenePos++;
            }
            switch (scenePos)
            {
                case 1: // Add more cases for each person saying something
                    rob.transform.position = new Vector3(74f, rob.transform.position.y, rob.transform.position.z);
                    todFacade.transform.position = new Vector3(72f, 4.24f, tod.transform.position.z);
                    rob.say("..."); // Say the dialogue
                    break;
                case 2:
                    todFacade.say("we really can't find this engine");
                    break;
                case 3:
                    rob.say("we'll keep looking.");
                    break;
                case 4:
                    todFacade.say("but we've searched everwhere");
                    break;
                case 5:
                    World.say("there's nothing here.");
                    break;
                
                default:
                    finishScene(1); // Replace 1 with the scene number
                    break;
            }
        }
    }
    private void playScene2() // Replace 0 with the scene number
    {
        if (rob.gameObject.transform.position.x > 290) // Replace true with the condition that you need for the scene to play
        {
            textUI.SetActive(false);
            runScene(2); // Replace 1 with the scene number
            if (Input.GetButtonDown("Skip"))
            {
                scenePos++;
            }
            if (song1.volume > 0)
            {
                song1.volume -= Time.deltaTime / 50;
            }
            else
            {
                song1.Stop();
            }
            switch (scenePos)
            {
                case 1:
                    todFacade.transform.position = new Vector3(289, 2.8f, rob.transform.position.z);
                    rob.transform.position = new Vector3(293, rob.transform.position.y, rob.transform.position.z);
                    rob.say("...");
                    break;
                case 2:
                    todFacade.transform.position = new Vector3(288, 2.8f, rob.transform.position.z);
                    todFacade.say("...");
                    break;
                case 3:
                    rob.say("..how did that picture end up there?");
                    break;
                case 4:
                    todFacade.say("...");
                    break;
                case 5:
                    rob.say("that's you... and that's me...");
                    break;
                case 6:
                    rob.say("...");
                    break;
                case 7:
                    rob.say("no...");
                    break;
                case 8:
                    rob.say("it can't be... i don't remember this place");
                    break;
                case 9:
                    rob.say("...");
                    break;
                case 10:
                    todFacade.say("...");
                    break;
                case 11:
                    rob.say("no.. this can't be home..");
                    break;
                case 12:
                    rob.say("...");
                    break;
                case 13:
                    World.say("...");
                    break;
                case 14:
                    Actor.stopSaying();
                    endScene();
                    break;
                case 21:
                    break;
            }
        }
    }
    private void endScene()
    {
        if(!song2.isPlaying)
        {
            song2.Play();
        }
        if(cam.orthographicSize < 7)
        {
            cam.orthographicSize += 0.2f * Time.deltaTime;
        }
        if(cam.transform.position.y < 13 && cam.orthographicSize >= 7) {
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y + (1.5f * Time.deltaTime), cam.transform.position.z);
        }
        timer += Time.deltaTime;
        Debug.Log(timer);
        if(timer >= 23)
        {
            textUI2.GetComponent<Image>().color = new Color(textUI2.GetComponent<Image>().color.r, textUI2.GetComponent<Image>().color.g, textUI2.GetComponent<Image>().color.b, textUI2.GetComponent<Image>().color.a+(0.15f*Time.deltaTime));
        }
        if(timer >= 33) {
            SceneManager.LoadScene(11);
        }
    }
}
