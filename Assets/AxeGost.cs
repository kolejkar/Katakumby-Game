using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeGost : MonoBehaviour
{
    public int health;
    private GameObject gost;
    private int action;
    private float timer = 0.0f;


    void Start()
    {
        health = 10;
        player = GameObject.Find("gracz");
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <=0.0f)
        {
            if (action == 1)
            {
                TeleportGost();
            }
            if (action == 2)
            {
                KilledGost();
            }
            action = 0;
        }
    }

    void TeleportGost()
    {
        //gost.GetComponentInChildren<Renderer>().enabled = true;
        var renderers = gost.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.enabled = !r.enabled;
        }
        Debug.Log("Teleporting ...");
    }

    void KilledGost()
    {
        Destroy(gost);
    }

    public AudioSource dead;
    public GameObject player;

    void OnTriggerEnter(Collider coll)
    {
        Debug.Log("Gost attack collider in: " + coll.gameObject.name);
        if (coll.gameObject.name == "AxeCollider" && engine.use_axe == true)
        {
            gost = transform.parent.gameObject;
            Debug.Log("You attack gost");
            health = health - 5;
            engine.use_axe = false;
            if (health == 0)
            {
                player.GetComponent<ImageCanvas>().image.gameObject.SetActive(false);
                Debug.Log("Killed gost");
                dead.Play();
                timer = 1.0f;
                action = 2;
                engine.gasts = engine.gasts + 1;
            }
            else
            {
                //gast.tick = -gast.tick;
                timer = 10.0f;
                action = 1;
                //gost.GetComponentInChildren<Renderer>().enabled = false;
                var renderers = gost.GetComponentsInChildren<Renderer>();
                foreach (Renderer r in renderers)
                {
                    r.enabled = !r.enabled;
                }
                
                player.GetComponent<ImageCanvas>().image.gameObject.SetActive(false);
            }
        }
    }
}
