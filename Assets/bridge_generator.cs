using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridge_generator : MonoBehaviour
{
    public GameObject bridge_1;
    public GameObject bridge_2;

    public GameObject stairs_1;
    public GameObject stairs_2;

    // Start is called before the first frame update
    void Start()
    {
        //bridges
        if (Random.Range(0, 100) < 50.0f)
        {
            var obj = Instantiate(bridge_1, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(0.8f, 3.0f, -1.5f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
        }
        else
        {
            var obj = Instantiate(bridge_2, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(1.2f, 3.0f, -1.5f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
        }

        //stairs
        if (Random.Range(0, 100) < 30.0f)
        {
            var obj = Instantiate(stairs_1, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
        }
        else
        {
            var obj = Instantiate(stairs_2, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeBridge()
    {
        var obj = Instantiate(bridge_1, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
        obj.transform.parent = gameObject.transform;
        obj.transform.localPosition += new Vector3(0.8f, 3.0f, -1.5f);
        obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
    }

    public void MakeStairs()
    {
        var obj = Instantiate(stairs_1, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
        obj.transform.parent = gameObject.transform;
        obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
    }
}
