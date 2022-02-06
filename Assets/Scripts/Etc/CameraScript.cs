using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private float dx = 1;
    private float dy = 1;
    public GameObject rob;
    public GameObject tod;
    public Camera cam;

    void Start()
    {
        
    }

    private void Update()
    {
        if(transform.position.x <= 2.85)
        {
            transform.position += new Vector3(dx * Time.deltaTime, 0, 0);
        } else
        {
            if (transform.position.y <= 2.7 && rob.transform.position.x >= -0.36 && tod.transform.position.y <= 3.1)
            {
                transform.position += new Vector3(0, dy * Time.deltaTime, 0);
            }
            if(transform.position.y >= 2.7 && rob.transform.position.x >= 3 && transform.position.y <= 3.5 && cam.orthographicSize <= 7)
            {
                cam.orthographicSize += 0.5f * Time.deltaTime;
            }
            if(cam.orthographicSize >= 6.9 && transform.position.y <= 5.75)
            {
                transform.position += new Vector3(0, (dy/1.5f) * Time.deltaTime, 0);
            }
            {
                
            }
        }
    }
}
