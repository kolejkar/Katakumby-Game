using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBake : MonoBehaviour
{
    public List<NavMeshSurface> surfaces;
    private int size = 0;
    private bool baked;

    private void Awake()
    {
        if (surfaces == null)
        {
            surfaces = new List<NavMeshSurface>();
            size = surfaces.Count;
            baked = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!baked)
        {
            if (size == surfaces.Count)
            {
                Bake();
                baked = true;
            }
            else
            {
                size = surfaces.Count;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!baked)
        {
            if (size == surfaces.Count)
            {
                Bake();
                baked = true;
            }
            else
            {
                size = surfaces.Count;
            }
        }
    }

    void Bake()
    {
        for (int i = 0; i < surfaces.Count; i++)
        {
            //surfaces[i].ClearAllNavMeshes();
            surfaces[i].BuildNavMesh();
            Debug.Log("Bake_surfaces");
        }
    }
}
