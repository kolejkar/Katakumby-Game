using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GastTouchObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    GameObject gui;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "gracz")
        {
            gui = FindObject(GameObject.Find("Canvas"), "EndGame");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            gui.SetActive(true);
        }
    }

    public static GameObject FindObject(GameObject parent, string name)
    {
        Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            if (t.name == name)
            {
                return t.gameObject;
            }
        }
        return null;
    }
}
