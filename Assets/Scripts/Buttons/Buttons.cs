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
        SceneManager.LoadScene(4);
    }

    public void iceButton()
    {
        SceneManager.LoadScene(6);
    }

    public void cityButton()
    {
        SceneManager.LoadScene(8);
    }

    public void junkyardButton()
    {
        SceneManager.LoadScene(10);
    }
}
