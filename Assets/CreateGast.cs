using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGast : MonoBehaviour
{
    public GameObject gast;
    public bool has_gast = false;

    private float timer = 0.0f;

    public ChestEngine chestEngine;

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
            if (!has_gast)
            {
                var obj = Instantiate(gast, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                            Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
                obj.transform.parent = gameObject.transform;
                chestEngine.gast = obj;
                has_gast = true;
            }
        }
    }
}
