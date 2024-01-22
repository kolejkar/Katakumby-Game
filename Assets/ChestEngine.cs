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

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        isGast = false;
        RandItems();
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
        }
        if (isEmpty == true)
        {
            //SpawnGast();
        }
        //Debug.Log(doorPoint.localEulerAngles.y);
    }

    public void SpawnGast()
    {
        if (isGast == false)
        {
            int p = Random.Range(0, 100);
            Debug.Log(p);
            if (p < 30.0f)
            {
                CreateGast createGast = this.GetComponent<CreateGast>();
                createGast.enabled = true;
            }
            isGast = true;
        }
    }

    public class ChestItems
    {
        public int wood;
        public int water;
    }
}
