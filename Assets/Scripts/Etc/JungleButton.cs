using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JungleButton : MonoBehaviour
{
    public void toJungle()
    {
        SceneManager.LoadScene(3);
    }
}
