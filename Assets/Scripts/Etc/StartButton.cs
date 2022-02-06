using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void NextScene()
    {
        Debug.Log("shouldwork");
        SceneManager.LoadScene(1);
    }
}
