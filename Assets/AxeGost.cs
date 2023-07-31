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
        //health = 10;
        player = GameObject.Find("gracz");
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <=0.0f)
        {
            if (action == 1)
            {
                TurnLight();
                TeleportGost();
            }
            if (action == 2)
            {
                TurnLight();
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

    void TurnLight()
    {

        gast gast1 = gost.transform.Find("Test").GetComponent<gast>();
        foreach (GameObject light in gast1.items)
        {
            light.GetComponent<Light>().enabled = true;
            object halo = light.GetComponent("Halo");
            var haloInfo = halo.GetType().GetProperty("enabled");
            haloInfo.SetValue(halo, true, null);
        }
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
        if (coll.gameObject.name == "book")
        { 
            gost = transform.parent.gameObject;
            health -= 5;
            Debug.Log("You attack gost");
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
