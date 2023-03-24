using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gast : MonoBehaviour
{
    /*public Transform transform;
    public Transform current;
    public static float count;*/
    // Start is called before the first frame update
    void Start()
    {
        /*current = transform;
        count = -10.0f;
        transform.Rotate(Vector3.up * -180.0f);*/
    }

    //public static float tick = 1.0f;
    // Update is called once per frame
    void Update()
    {       
        /*if (count >= 10.0f)
        {
            transform.Rotate(Vector3.up * -180.0f);
            tick = -0.1f;
        }
        else
        if ( count <= -10.0f)
        {
            transform.Rotate(Vector3.up * 180.0f);
            tick = 0.1f;
        }
        transform.position += transform.forward * -0.1f;
        count = count + tick;*/
    }

    void OnTriggerEnter(Collider coll)
    {
        //Debug.Log("Touch collider in: " + coll.gameObject.name);
        if (coll.gameObject.name == "TourchLight" && GetComponentInChildren<Renderer>().enabled == true)
        {
            //Debug.Log("Light");
            coll.gameObject.GetComponent<Light>().enabled = false;
            object halo = coll.gameObject.GetComponent("Halo");
            var haloInfo = halo.GetType().GetProperty("enabled");
            haloInfo.SetValue(halo, false, null);
        }
        if (coll.gameObject.name == "gracz" && gameObject.activeSelf)
        {
            coll.gameObject.GetComponent<ImageCanvas>().image.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        //Debug.Log("Touch collider in: " + coll.gameObject.name);
        if (coll.gameObject.name == "TourchLight")
        {
            //Debug.Log("Light");
            coll.gameObject.GetComponent<Light>().enabled = true;
            object halo = coll.gameObject.GetComponent("Halo");
            var haloInfo = halo.GetType().GetProperty("enabled");
            haloInfo.SetValue(halo, true, null);
        }
        if (coll.gameObject.name == "gracz")
        {
            coll.gameObject.GetComponent<ImageCanvas>().image.gameObject.SetActive(false);
        }
    }
}
