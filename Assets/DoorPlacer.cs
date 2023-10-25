using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPlacer : MonoBehaviour
{
    public GameObject door;

    public GameObject mushroom;
    public GameObject mushroom1;

    // Start is called before the first frame update
    void Start()
    {
        float typ = Random.Range(0, 100);
        if (typ > 50.0f)
        {
            door.SetActive(false);
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
}
