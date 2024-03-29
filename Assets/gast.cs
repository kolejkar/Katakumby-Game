﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gast : MonoBehaviour
{
    public List<GameObject> items;

    /*public Transform transform;
    public Transform current;
    public static float count;*/
    // Start is called before the first frame update
    void Start()
    {
        items = new List<GameObject>();
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
        if (coll.gameObject.name == "TourchLight")
        {
            TourchLight(coll.gameObject, false);
            items.Add(coll.gameObject);
        }
        /*if (coll.gameObject.name == "gracz" && gameObject.activeSelf)
        {
            coll.gameObject.GetComponent<ImageCanvas>().image.gameObject.SetActive(true);
        }*/
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.name == "TourchLight")
        {
            TourchLight(coll.gameObject, true);
            items.Remove(coll.gameObject);
        }
        /*if (coll.gameObject.name == "gracz")
        {
            coll.gameObject.GetComponent<ImageCanvas>().image.gameObject.SetActive(false);
        }*/
    }

    private void TourchLight(GameObject tourchlight, bool active)
    {
        foreach (Transform light in tourchlight.transform)
        {
            light.gameObject.SetActive(active);
            /*light.GetComponent<Light>().enabled = true;
            object halo = light.GetComponent("Halo");
            var haloInfo = halo.GetType().GetProperty("enabled");
            haloInfo.SetValue(halo, true, null);*/
        }
    }
}
