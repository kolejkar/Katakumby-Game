using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEngine : MonoBehaviour
{
    public bool openDoor;
    public bool closeDoor;
    public bool isOpen;
    public Transform doorPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (openDoor == true && isOpen == false && (doorPoint.localEulerAngles.y < 90.0f || doorPoint.localEulerAngles.y > 358.0f))
        {
            doorPoint.Rotate(0.0f, 1.0f, 0.0f, Space.Self);
        }
        else
        if (openDoor == true)
        {
            openDoor = false;
            isOpen = true;
        }
        if (closeDoor == true && isOpen == true && (doorPoint.localEulerAngles.y > 0.0f && doorPoint.localEulerAngles.y < 91.0f))
        {
            doorPoint.Rotate(0.0f, -1.0f, 0.0f, Space.Self);
        }
        else
        if (closeDoor == true)
        {
            closeDoor = false;
            isOpen = false;
        }
        //Debug.Log(doorPoint.localEulerAngles.y);
    }
}
