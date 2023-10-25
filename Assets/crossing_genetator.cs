using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossing_genetator : MonoBehaviour
{
    public GameObject door_normal;
    public GameObject door_secret;
    public GameObject bottle;
    public GameObject wood;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 100) < 50.0f)
        {
            Debug.Log("Create doors.");
            float id = Random.Range(0, 3);
            if (id == 0)
            {
                if (Random.Range(0, 100) < 50.0f)
                {
                    var obj = Instantiate(door_normal, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                    Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
                    obj.transform.parent = gameObject.transform;
                    obj.transform.localPosition += new Vector3(0.0f, 0.0f, 1.75f);
                    obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
                }
                else
                {
                    var obj = Instantiate(door_secret, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                    Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
                    obj.transform.parent = gameObject.transform;
                    obj.transform.localPosition += new Vector3(0.0f, 0.0f, 1.75f);
                    obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
                }
            }
            if (id == 1)
            {
                if (Random.Range(0, 100) < 50.0f)
                {
                    var obj = Instantiate(door_normal, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                    Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
                    obj.transform.parent = gameObject.transform;
                    obj.transform.localPosition += new Vector3(0.0f, 0.0f, -1.75f);
                    obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + 180.0f, obj.transform.localRotation.z));
                }
                else
                {
                    var obj = Instantiate(door_secret, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                    Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
                    obj.transform.parent = gameObject.transform;
                    obj.transform.localPosition += new Vector3(0.0f, 0.0f, -1.75f);
                    obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + 180.0f, obj.transform.localRotation.z));
                }
            }
            if (id == 2)
            {
                if (Random.Range(0, 100) < 50.0f)
                {
                    var obj = Instantiate(door_normal, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                    Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
                    obj.transform.parent = gameObject.transform;
                    obj.transform.localPosition += new Vector3(-1.75f, 0.0f, 0.0f);
                    obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y - 90.0f, obj.transform.localRotation.z));
                }
                else
                {
                    var obj = Instantiate(door_secret, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                    Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
                    obj.transform.parent = gameObject.transform;
                    obj.transform.localPosition += new Vector3(-1.75f, 0.0f, 0.0f);
                    obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y - 90.0f, obj.transform.localRotation.z));
                }
            }
        }
        int value = Random.Range(0, 100);
        Debug.Log("Create items. Crossing " + value);
        if (value < 30.0f)
        {
            var obj = Instantiate(bottle, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(1.26f,1.775f, 0.84f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
            obj = Instantiate(bottle, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(1.22f, 1.775f, 0.625f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
            obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(1.228f,1.725f, -0.271f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + -10.77f, obj.transform.localRotation.z));
        }
        if (value < 50.0f)
        {
            var obj = Instantiate(bottle, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(1.12f, 0.4f, -0.569f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
            obj = Instantiate(bottle, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(1.208f, 1.091f, 0.701f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
            obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(1.35f, 0.35f, 0.046f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
            obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(1.102f, 0.55f, 0.147f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + -20.77f, obj.transform.localRotation.z));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
