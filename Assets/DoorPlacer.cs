using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPlacer : MonoBehaviour
{
    public GameObject door_work;
    public GameObject door_destroy;

    public GameObject mushroom;
    public GameObject mushroom1;

    public bool isSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        float typ = Random.Range(0, 100);
        if (typ > 50.0f)
        {
            typ = Random.Range(0, 100);
            if (typ > 10.0f && isSpawn == false && CheckLevel.levelId > 1)
            {
                door_destroy.SetActive(true);
            }
            else
            {
                door_work.SetActive(true);
            }
        }

        typ = Random.Range(0, 100);
        if (typ > 20.0f)
        {
            mushroom.SetActive(false);
        }

        typ = Random.Range(0, 100);
        if (typ > 20.0f)
        {
            mushroom1.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RepairDoor()
    {
        door_work.SetActive(true);
        door_destroy.SetActive(false);
    }
}
