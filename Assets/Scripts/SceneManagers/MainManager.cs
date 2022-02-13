using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    // Scene Variables

    public static int scenePos = 1;
    public static int checkPoint;
    public static int world;

    public void finishScene(int scene)
    {
        Actor.stopSaying();
        scenePos = 1; // Resets the scene position to 1
        checkPoint++;
    }

    public void runScene(int scene)
    {
        Actor.startSaying();
    }
}