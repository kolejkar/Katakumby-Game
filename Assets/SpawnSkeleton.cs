using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkeleton : MonoBehaviour
{
    public GameObject skeleton;
    public bool has_skeleton = false;

    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            if (!has_skeleton)
            {
                var obj = Instantiate(skeleton, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                            Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
                obj.transform.parent = gameObject.transform.parent;
                has_skeleton = true;
            }
        }
    }
}
