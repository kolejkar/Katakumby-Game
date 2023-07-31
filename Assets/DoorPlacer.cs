using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPlacer : MonoBehaviour
{
    public GameObject door;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 100) > 50.0f)
        {
            door.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
