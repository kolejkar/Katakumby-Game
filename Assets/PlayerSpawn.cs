using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject player;
    public bool has_player = false;

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
            if (!has_player)
            {
                var obj = Instantiate(player, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                            Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
                obj.transform.parent = gameObject.transform;
                obj.transform.position += new Vector3(0.0f, 3.95f, 0.0f);
                has_player = true;
            }
        }
    }
}
