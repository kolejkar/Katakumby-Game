using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_stairs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider coll)
    {
        Debug.Log("Mushroom check: " + coll.gameObject.transform.parent.gameObject.name);
        if (coll.gameObject.transform.parent.gameObject.name == "holeGood")
        {
            Destroy(this);
        }
    }
}
