using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    public SkeletonAI skeletonAI;

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
        if (coll.gameObject.name == "gracz")
        {
            skeletonAI.hitPlayer = true;
            skeletonAI.attackPlayer = false;
            skeletonAI.changeStatus = true;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        skeletonAI.hitPlayer = false;
        skeletonAI.attackPlayer = true;
        skeletonAI.changeStatus = true;
    }
}
