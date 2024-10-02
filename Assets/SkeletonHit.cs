using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonHit : MonoBehaviour
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
            gui = GastTouchObj.FindObject(GameObject.Find("Canvas"), "EndGame");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            gui.SetActive(true);
        }
    }
}
