using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateManager : MonoBehaviour
{
    public GameObject[] plateDoors;
    public bool[][] doorStatuses;
    public GameObject[] plates;
    public PlateManager plateManager;

    private void Start()
    {
        plateManager.doorStatuses = new bool[2][];
        for(int i = 0; i < doorStatuses.Length; i++)
        {
            doorStatuses[i] = new bool[plateDoors.Length];
        }
    }

    private void Update()
    {
        for(int i = 0; i < plateDoors.Length; i++)
        {
            if(doorStatuses[0][i] && doorStatuses[1][i])
            {
                plateDoors[i].SetActive(false);
            }
        }
    }
}
