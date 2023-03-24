using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sign_placer : MonoBehaviour
{
    public GameObject sign_turn;
    public GameObject sign_foward;
    public GameObject sign_up;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 100) < 50.0f)
        {
            Debug.Log("Create signs.");
            if (gameObject.name == "room_crossing")
            {
                if (Random.Range(0, 100) < 50.0f)
                {
                    var obj = Instantiate(sign_turn, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                        Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
                    obj.transform.parent = gameObject.transform;
                    obj.transform.localPosition += new Vector3(0.0f, 2.15f, 0.0f);
                    obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x - 180.0f, obj.transform.localRotation.y + 90.0f, obj.transform.localRotation.z));
                }
                else
                {
                    var obj = Instantiate(sign_foward, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                        Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
                    obj.transform.parent = gameObject.transform;
                    obj.transform.localPosition += new Vector3(0.0f, 2.15f, -3.0f);
                    obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x - 180.0f, obj.transform.localRotation.y + 180.0f, obj.transform.localRotation.z));
                }
            }
            if (gameObject.name == "holeGood")
            {
                var obj = Instantiate(sign_up, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                    Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
                obj.transform.parent = gameObject.transform;
                obj.transform.localPosition += new Vector3(-1.5f, 2.0f, 1.5f);
                obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x - 180.0f, obj.transform.localRotation.y - 90.0f, obj.transform.localRotation.z));
            }
            if (gameObject.name == "crossing")
            {
                Debug.Log("Test crossing");
                if (Random.Range(0, 100) < 50.0f)
                {
                    var obj = Instantiate(sign_turn, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                        Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
                    obj.transform.parent = gameObject.transform;
                    obj.transform.localPosition += new Vector3(1.5f, 1.5f, 4.2f);
                    obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x - 180.0f, obj.transform.localRotation.y + 90.0f, obj.transform.localRotation.z));
                }
                else
                if (Random.Range(0, 100) < 50.0f)
                {
                    var obj = Instantiate(sign_foward, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                        Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
                    obj.transform.parent = gameObject.transform;
                    obj.transform.localPosition += new Vector3(0.0f, 2.15f, 4.0f);
                    obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x - 180.0f, obj.transform.localRotation.y + 180.0f, obj.transform.localRotation.z));
                }
                else
                {
                    var obj = Instantiate(sign_turn, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                        Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
                    obj.transform.parent = gameObject.transform;
                    obj.transform.localPosition += new Vector3(0.0f, 2.15f, 4.0f);
                    obj.transform.localRotation = Quaternion.Euler(new Vector3(obj.transform.localRotation.x - 180.0f, obj.transform.localRotation.y + 90.0f, obj.transform.localRotation.z));
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
