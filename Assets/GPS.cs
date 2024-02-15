using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GPS : MonoBehaviour
{
    public NavMeshAgent Agent;

    public Transform trans;
    public GameObject type_room;
    private bool new_room;
    // Start is called before the first frame update
    void Start()
    {
        //transform.Rotate(Vector3.up * 180.0f);
        //new_room = false;
        GameObject level = GameObject.Find("Level");
        if ((level == null))
        {
            level = GameObject.Find("Level(Clone)");
        }
        items = GetChildren(level.transform);

        RandSection();
    }

    void RandRotate()
    {
        Debug.Log(type_room.name);
        if (type_room.name == "corossing")
        {
            if (type_room.transform.position.x - 0.2 < transform.position.x && type_room.transform.position.x + 0.2 > transform.position.x)
            {
                if (type_room.transform.position.z - 0.2 < transform.position.z && type_room.transform.position.z + 0.2 > transform.position.z)
                {
                    float id = Random.Range(0, 3);
                    if (id == 0)
                        trans.Rotate(Vector3.up * 180.0f);
                    if (id == 1)
                        trans.Rotate(Vector3.up * 90.0f);
                    if (id == 2)
                        trans.Rotate(Vector3.up * -90.0f);
                    new_room = false;
                }
            }
        }
        else
        if (type_room.name == "room_end")
        {
            //if (type_room.transform.position.x - 0.2 < transform.position.x && type_room.transform.position.x + 0.2 > transform.position.x)
            {
                //if (type_room.transform.position.z - 0.2 < transform.position.z && type_room.transform.position.z + 0.2 > transform.position.z)
                {
                    trans.Rotate(Vector3.up * 180.0f);
                    new_room = false;
                }
            }
        }
        else
        if (type_room.name == "corner")
        {
            if (type_room.transform.position.x - 0.2 < transform.position.x && type_room.transform.position.x + 0.2 > transform.position.x)
            {
                if (type_room.transform.position.z - 0.2 < transform.position.z && type_room.transform.position.z + 0.2 > transform.position.z)
                {
                    trans.Rotate(Vector3.up * 180.0f);
                    new_room = false;
                }
            }
        }
        else
        if (type_room.name == "T_crossing")
        {
            if (type_room.transform.position.x - 0.2 < transform.position.x && type_room.transform.position.x + 0.2 > transform.position.x)
            {
                if (type_room.transform.position.z - 0.2 < transform.position.z && type_room.transform.position.z + 0.2 > transform.position.z)
                {
                    trans.Rotate(Vector3.up * 180.0f);
                    new_room = false;
                }
            }
        }
        else
        if (type_room.name == "room_crossing")
        {
            if (type_room.transform.position.x - 0.2 < transform.position.x && type_room.transform.position.x + 0.2 > transform.position.x)
            {
                if (type_room.transform.position.z - 0.2 < transform.position.z && type_room.transform.position.z + 0.2 > transform.position.z)
                {
                    trans.Rotate(Vector3.up * 180.0f);
                    new_room = false;
                }
            }
        }
        else
        {
            new_room = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (new_room == true)
        {
            RandRotate();
        }
        trans.Translate(transform.forward * Time.deltaTime, Space.World);*/
        if (this.type_room.transform.position == this.floor.transform.position)
        {
            RandSection();
        }

    }

    /*void OnCollisionEnter(Collision coll)
    {
        Debug.Log(coll.gameObject.name);
        if (coll.gameObject.name == "floor" && new_room == false)
        {
            type_room = coll.gameObject.transform.parent.gameObject;
            new_room = true;
            return;
        }
        else
        if (coll.gameObject.name == "end" && coll.gameObject.transform.parent.gameObject.name == "wall_end")
        {
            Debug.Log("end");
            trans.Rotate(Vector3.up * -180.0f);
            return;
        }
        //type_room = null;
    }*/

    void OnTriggerEnter(Collider coll)
    {
        Debug.Log(coll.gameObject.name);
        if (coll.gameObject.name == "floor")
        {
            type_room = coll.gameObject/*.transform.parent.gameObject*/;
            //new_room = true;
            //return;
        }
        /*else
        if (coll.gameObject.name == "end" && coll.gameObject.transform.parent.gameObject.name == "wall_end")
        {
            Debug.Log("end");
            trans.Rotate(Vector3.up * 180.0f);
            return;
        }*/
        //type_room = null;
    }

    public int room_id = -1;
    public GameObject floor;
    public List<GameObject> items;

    void RandSection()
    {
        int old_room_id = room_id;
        
        string room_name_id = "";

        while (true)
        {
            room_id = Random.Range(0, items.Count);
            room_name_id = items[room_id].name;
            if (room_name_id == "end_wall(Clone)")
            {
                continue;
            }
            if (room_id != old_room_id)
            {
                break;
            }
        }

        room_name_id = room_name_id.Replace("(Clone)", "");
        
        Debug.Log(room_name_id);

        floor = FindInChildren(items[room_id], room_name_id);

        Debug.Log(floor.name);

        floor = FindInChildren(floor, CheckSectionsName(room_name_id));

        Debug.Log(floor.name);

        floor = FindInChildren(floor, "Floor");

        Debug.Log(floor.name);

        Agent.SetDestination(floor.transform.position);
    }

    private List<GameObject> GetChildren(Transform t)
    {
        List<GameObject> children = new List<GameObject>();

        foreach (Transform child in t)
        {
            children.Add(child.gameObject);
            //children.AddRange(GetAllChildren(child.gameObject));
        }

        return children;
    }

    private string CheckSectionsName(string room_name)
    {
        if (room_name == "2_lvl")
        {
            room_name = "hole_" + room_name;
        }
        else
        if (room_name.IndexOf("room") > -1)
        {
            //room_name = room_name;
        }
        else
        {
            room_name = "corridor_" + room_name;
        }

        return room_name;
    }

    private GameObject FindInChildren(GameObject obj, string name)
    {
        List<GameObject> list;
        GameObject item;
        list = GetChildren(obj.transform);
        item = list.Find(g => g.name == name);
        if (item)
        {
            return item;
        }
        else
        {
            return obj;
        }

    }
}
