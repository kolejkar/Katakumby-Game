using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AddToList : MonoBehaviour
{
    public NavMeshSurface surface;
    private bool added;

    // Start is called before the first frame update
    void Start()
    {
        added = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!added)
        {
            NavMeshBake navMeshBake = GameObject.Find("Level(Clone)").GetComponent<NavMeshBake>();
            navMeshBake.surfaces.Add(surface);
            added = true;
        }
    }

}
