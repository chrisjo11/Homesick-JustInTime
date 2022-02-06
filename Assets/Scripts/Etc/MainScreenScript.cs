using System.Collections;
using UnityEngine;

public class MainScreenScript : MonoBehaviour
{
    public GameObject screen;

    void Start()
    {
        Debug.Log("works");
        screen.SetActive(false);
    }
}
