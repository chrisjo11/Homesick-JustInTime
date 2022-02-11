using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length, startpos;
    public GameObject cam;
    public GameObject cam1;
    public GameObject rob;
    public float parralaxEffect;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rob.activeInHierarchy)
        {
            float dist = (cam.transform.position.x * parralaxEffect);

            transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        } else
        {
            float dist = (cam1.transform.position.x * parralaxEffect);

            transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        }
        
    }
}
