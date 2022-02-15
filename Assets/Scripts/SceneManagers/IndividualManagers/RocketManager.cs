using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketManager : MonoBehaviour
{
    public GameObject rocket;

    private void Update()
    {
        if(rocket.transform.position.y < 300)
        {
            rocket.transform.position = new Vector3(0, rocket.transform.position.y+(8f*Time.deltaTime), rocket.transform.position.z);
        } else
        {
            rocket.transform.position = new Vector3(0, 0, rocket.transform.position.z);
        }
    }
}
