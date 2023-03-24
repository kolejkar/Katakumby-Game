using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hole_generator : MonoBehaviour
{
    public GameObject bottle;
    public GameObject wood;
    // Start is called before the first frame update
    void Start()
    {
        int value = Random.Range(0, 100);
        if (value > 80.0f)
        {
            var obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                  Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(0.95f, 0.35f, -1.23f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + 28.6f, obj.transform.localRotation.z));
            obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                  Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(1.1f, 0.35f, 0.65f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + 16.5f, obj.transform.localRotation.z));
            obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                  Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(1.1f, 0.57f, 1.15f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
        }
        if (value > 50.0f)
        {
            var obj = Instantiate(bottle, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(1.212f, 1.095f, 0.79f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
            obj = Instantiate(bottle, new Vector3(transform.position.x, transform.position.y, transform.position.z),
               Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(1.212f, 1.095f, 0.55f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y, obj.transform.localRotation.z));
            obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                 Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(1.28f, 1.06f, -0.37f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + 16.5f, obj.transform.localRotation.z));
        }
        if (value > 30.0f)
        {
            var obj = Instantiate(wood, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                  Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition += new Vector3(1.23f, 1.73f, -0.06f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x, obj.transform.localRotation.y + 28.6f, obj.transform.localRotation.z));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
