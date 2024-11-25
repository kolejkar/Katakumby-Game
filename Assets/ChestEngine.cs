using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestEngine : MonoBehaviour
{
    public bool openChest;
    public bool closeChest;
    public bool isOpen;
    public Transform chestPoint;

    public ChestItems chestItems;
    public bool isEmpty;

    public bool isGast;

    public AudioSource chest;

    bool played;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        isGast = false;
        RandItems();
        played = false;
    }

    void RandItems()
    {
        chestItems = new ChestItems();
        chestItems.wood = Random.Range(0, 10);
        chestItems.water = Random.Range(0, 2);
        isEmpty = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (openChest == true && isOpen == false && (chestPoint.localEulerAngles.y < 15.0f || chestPoint.localEulerAngles.y > 358.0f))
        {
            chestPoint.Rotate(0.0f, 1.0f, 0.0f, Space.Self);
        }
        else
        if (openChest == true)
        {
            openChest = false;
            isOpen = true;
            played = false;
        }
        if (closeChest == true && isOpen == true && (chestPoint.localEulerAngles.y > 0.0f && chestPoint.localEulerAngles.y < (15.0f + 1.0f)))
        {
            chestPoint.Rotate(0.0f, -1.0f, 0.0f, Space.Self);
        }
        else
        if (closeChest == true)
        {
            closeChest = false;
            isOpen = false;
            played = false;
        }
        if (isEmpty == true)
        {
            //SpawnGast();
        }
        if (closeChest || openChest)
        {
            if (played == false)
            {
                chest.Play();
                played = true;
            }
        }
        //Debug.Log(doorPoint.localEulerAngles.y);
    }

    public class ChestItems
    {
        public int wood;
        public int water;
    }
}
