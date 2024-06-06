using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterDropInCave : MonoBehaviour
{
    //public AudioSource waterDrop;

    private float timer = 0.0f;
    public float interval = 2.0f;

    public GameObject water;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = interval;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f && gameObject.name.IndexOf("drop_water") > -1)
        {
            var obj = Instantiate(water, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                   Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            timer = interval;
        }
    }

    public GameObject waterTouch;

    void PlaySound()
    {
        var obj = Instantiate(waterTouch, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                   Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
    }

    void OnCollisionEnter(Collision collision)
    {
        PlaySound();
        Destroy(gameObject);
    }
}
