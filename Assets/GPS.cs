using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GPS : MonoBehaviour
{
    public NavMeshAgent Agent;

    public GameObject type_room;
    // Start is called before the first frame update
    void Start()
    {
        GameObject level = GameObject.Find("Level");
        if ((level == null))
        {
            level = GameObject.Find("Level(Clone)");
        }
        items = GetChildren(level.transform);

        RandSection();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.type_room.transform.position == this.floor.transform.position)
        {
            RandSection();
        }

    }


    void OnTriggerEnter(Collider coll)
    {
        Debug.Log(coll.gameObject.name);
        if (coll.gameObject.name == "floor")
        {
            type_room = coll.gameObject;
        }
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
            if (room_name_id.IndexOf("end_wall") > -1)
            {
                continue;
            }
            if (room_id != old_room_id)
            {
                break;
            } 
        }

        room_name_id = room_name_id.Replace("(Clone)", "");

        if (room_name_id.IndexOf("room_spawn") > -1)
        {
            items[room_id] = FindInChildren(items[room_id], "room_end_spawn");
        }
        
        //Debug.Log(room_name_id);

        floor = FindInChildren(items[room_id], room_name_id);

        //Debug.Log(floor.name);

        floor = FindInChildren(floor, CheckSectionsName(room_name_id));

        //Debug.Log(floor.name);

        floor = FindInChildren(floor, "Floor");

        //Debug.Log(floor.name);

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
