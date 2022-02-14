using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField] private Text text;
    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void displayMessage(string message, Color color)
    {
        text.color = color;
        if (!isActive)
        {
            gameObject.SetActive(true);
            isActive = true;
        }
        Debug.Log(color);
        text.text = message;
    }

    public void destroyMessage()
    {
        if(isActive)
        {
            gameObject.SetActive(false);
            isActive = false;
        }
    }
}
