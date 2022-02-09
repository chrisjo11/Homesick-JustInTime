using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField] private Text text;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayMessage(string message)
    {
        gameObject.SetActive(true);
        text.text = message;
    }

    public void destroyMessage()
    {
        gameObject.SetActive(false);
    }
}
