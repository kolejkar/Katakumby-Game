using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public float radius = 3.0f;
    public SphereCollider collider;
    public GameObject effect;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float startTime = 0.0f;

    private int repeat = 0;

    // Update is called once per frame
    void Update()
    {
        if (startTime < 0.0f)
        {
            effect.SetActive(true);
            if (collider.radius <= radius)
            {
                collider.radius += 0.5f;
            }
            else
            {
                repeat++;
                collider.radius = 0.1f;
            }
            if (repeat == 2)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            startTime -= Time.deltaTime;
        }
    }
}
