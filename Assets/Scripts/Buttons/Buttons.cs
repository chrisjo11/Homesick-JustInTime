using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void startButton()
    {
        SceneManager.LoadScene(1);
    }

    public void settingsButton()
    {
        SceneManager.LoadScene(2);
    }

    public void jungleButton()
    {
        SceneManager.LoadScene(3);
    }

    public void iceButton()
    {
        SceneManager.LoadScene(4);
    }

    public void cityButton()
    {
        SceneManager.LoadScene(5);
    }

    public void junkyardButton()
    {
        SceneManager.LoadScene(6);
    }
}
