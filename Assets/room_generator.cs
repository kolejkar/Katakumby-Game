using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room_generator : MonoBehaviour
{
    public GameObject door_normal;
    public GameObject door_secret;
    //public GameObject box;
    public GameObject bottle;
    public GameObject wood;
    public GameObject chest;

    private bool isSpawn = false;
    private bool startroom;
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.name == "room_end_spawn")
        {
            StartItems();
            startroom = true;
            isSpawn = true;           
        }
        else
        if (this.gameObject.name == "room_normal")
        {
            NormalItems();
        }
        else
        if (this.gameObject.name == "room_T_crossing")
        {
            CrossingItems();
        }
        else
        if (this.gameObject.name.IndexOf("room_end") > -1)
        {
            EndItems();
            startroom = false;
        }
        GenerateDoors();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartItems()
    {
        Debug.Log("Create items. Room start ");
        var obj = Instantiate(bottle, new Vector3(transform.position.x, transform.position.y, transform.position.z),
            Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z)));
        obj.transform.parent = gameObject.transform;
        obj.transform.localPosition += new Vector3(-3.3f, 1.37f, -3.32f);
        obj.transform.localRotation = 
            Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
        obj = Instantiate(bottle, new Vector3(transform.position.x, transform.position.y, transform.position.z),
            Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z)));
        obj.transform.parent = gameObject.transform;
        obj.transform.localPosition += new Vector3(-3.05f, 1.37f, -3.32f);
        obj.transform.localRotation = 
            Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
        obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
        obj.transform.parent = gameObject.transform;
        obj.transform.localPosition += new Vector3(-2.255f, 0.35f, -3.14f);
        obj.transform.localRotation = 
            Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + 107.0f, obj.transform.localRotation.z));
        obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
        obj.transform.parent = gameObject.transform;
        obj.transform.localPosition += new Vector3(-3.306f, 0.572f, -2.725f);
        obj.transform.localRotation = 
            Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + 185f, obj.transform.localRotation.z));
        obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
        obj.transform.parent = gameObject.transform;
        obj.transform.localPosition += new Vector3(-2.553f, 0.572f, -2.547f);
        obj.transform.localRotation = 
            Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + 217f, obj.transform.localRotation.z));
        obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
              Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
        obj.transform.parent = gameObject.transform;
        obj.transform.localPosition += new Vector3(-1.848f, 0.35f, -3.0f);
        obj.transform.localRotation = 
            Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + 100.0f, obj.transform.localRotation.z));
    }

    void EndItems()
    {
        //if (Random.Range(0, 100) < 20.0f)
        //{
        /*var obj1 = Instantiate(box, new Vector3(transform.position.x, transform.position.y, transform.position.z),
            Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z)));
        obj1.transform.parent = gameObject.transform;
        obj1.transform.localPosition += new Vector3(0.0f, 0.75f, 0.0f);
        obj1.transform.localRotation = Quaternion.Euler(new Vector3(obj1.transform.localRotation.x, obj1.transform.localRotation.y, obj1.transform.localRotation.z));
        //}*/
        //StartItems();

        int value = Random.Range(0, 100);
        Debug.Log("Create items. Room end " + value);
        if (value < 50.0f)
        {
            var obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(2.957f, 3.35f, -2.641f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + 28.69f, obj.transform.localRotation.z));
            obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(2.734f, 3.35f, -2.032f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + 13.61f, obj.transform.localRotation.z));
            obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(2.25f, 3.559f, -2.536f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + -46.2f, obj.transform.localRotation.z));
            obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(1.719f, 3.35f, -3.073f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + 105.1f, obj.transform.localRotation.z));
        }
        //if (value < 30.0f)
        {
            var obj = Instantiate(bottle, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(2.58f, 3.4f, 3.21f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
            obj = Instantiate(bottle, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(2.776f, 3.4f, 3.23f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
        }
        if (value < 60.0f)
        {
            var obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
              Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(-0.149f, 3.35f, 2.184f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + 31.8f, obj.transform.localRotation.z));
            obj = Instantiate(bottle, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(-0.397f, 3.4f, 2.268f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
        }
    }

    void NormalItems()
    {
        int value = Random.Range(0, 100);
        Debug.Log("Create items. Room normal " + value);
        if (value < 90.0f)
        {
            var obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
              Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(3.047f, 0.553f, -2.617f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + 18.0f, obj.transform.localRotation.z));
            obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
              Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(2.799f, 0.35f, -2.438f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + 30.0f, obj.transform.localRotation.z));
            obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
              Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(3.137f, 0.35f, -0.901f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
            obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
              Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(2.555f, 0.35f, -1.659f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
            obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
              Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(2.346f, 0.601f, -1.462f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + -30.0f, obj.transform.localRotation.z));
            obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
              Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(2.211f, 0.567f, -2.28f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + -30.0f, obj.transform.localRotation.z));
        }
        if (value < 60.0f)
        {
            var obj = Instantiate(bottle, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(-3.15f, 1.2f, -1.5f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
            obj = Instantiate(bottle, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(-3.2f, 1.2f, -2.5f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
            obj = Instantiate(bottle, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(-3.2f, 1.2f, -2.7f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
            obj = Instantiate(bottle, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(-3.2f, 1.2f, -2.9f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
        }
        if (value < 45.0f)
        {
            var obj = Instantiate(bottle, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(-3.22f, 1.196f, 2.95f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
            obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
             Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(-3.256f, 1.146f, 1.965f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + 8.19f, obj.transform.localRotation.z));
        }
    }

    void CrossingItems()
    {
        int value = Random.Range(0, 100);
        Debug.Log("Create items. Room crossing " + value);
        if (value < 90.0f)
        {
            var obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
              Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(3.047f, 0.553f, -2.617f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + 18.0f, obj.transform.localRotation.z));
            obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
              Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(2.799f, 0.35f, -2.438f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + 30.0f, obj.transform.localRotation.z));
            obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
              Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(3.137f, 0.35f, -0.901f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
            obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
              Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(2.555f, 0.35f, -1.659f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
            obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
              Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(2.346f, 0.601f, -1.462f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + -30.0f, obj.transform.localRotation.z));
            obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
              Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(2.211f, 0.567f, -2.28f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + -30.0f, obj.transform.localRotation.z));
        }
        value = Random.Range(0, 100);
        if (value < 90.0f)
        {
            var obj = Instantiate(chest, new Vector3(transform.position.x, transform.position.y, transform.position.z),
              Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(0.0f, 0.3f, 2.2f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
        }
    }

    void GenerateDoors()
    {
        if (Random.Range(0, 100) < 50.0f /*&& !(gameObject.name == "room_end_spawn")*/)
        {
            Debug.Log("Create doors.");
            if (Random.Range(0, 100) > 30.0f && isSpawn == false && CheckLevel.levelId > 1)
            {
                var obj = Instantiate(door_secret, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                    Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
                obj.transform.parent = gameObject.transform;
                if (startroom == true)
                {
                    obj.transform.localPosition += new Vector3(0.0f, 0.0f, -3.75f);
                }
                else
                {
                    obj.transform.localPosition += new Vector3(0.0f, 3.0f, 3.75f);
                }
                obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + 180.0f, obj.transform.localRotation.z));
            }
            else
            {
                var obj = Instantiate(door_normal, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                    Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
                obj.transform.parent = gameObject.transform;
                if (startroom == true)
                {
                    obj.transform.localPosition += new Vector3(0.0f, 0.0f, -3.75f);
                }
                else
                {
                    obj.transform.localPosition += new Vector3(0.0f, 3.0f, -3.75f);
                }
                obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + 180.0f, obj.transform.localRotation.z));
                obj.GetComponent<DoorPlacer>().isSpawn = isSpawn;
            }
        }
    }
}
