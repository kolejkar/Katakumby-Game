﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLight : MonoBehaviour
{
    public GameObject light;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLight()
    {
        light.SetActive(true);
    }
}
