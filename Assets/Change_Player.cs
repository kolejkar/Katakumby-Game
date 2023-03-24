using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Player : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
