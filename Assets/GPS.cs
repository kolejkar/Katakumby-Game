using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour
{
    public Transform trans;
    private GameObject type_room;
    private bool new_room;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(Vector3.up * 180.0f);
        new_room = false;
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
        if (new_room == true)
        {
            RandRotate();
        }
        trans.Translate(transform.forward * Time.deltaTime, Space.World);
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
            trans.Rotate(Vector3.up * 180.0f);
            return;
        }
        //type_room = null;
    }
}
