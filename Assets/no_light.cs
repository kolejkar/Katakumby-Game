using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class no_light : MonoBehaviour
{
    public GameObject touch1;
    public GameObject touch2;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 100) > 10.0f)
        {
            Destroy(touch1);
            Destroy(touch2);
        }
        else
        {
            if (Random.Range(0, 100) > 50.0f)
            {
                Destroy(touch1);
            }
            else
            {
                Destroy(touch2);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
