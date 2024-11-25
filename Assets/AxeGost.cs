using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AxeGost : MonoBehaviour
{
    public int health;
    private GameObject gost;
    public int action;
    private float timer = 0.0f;


    void Start()
    {
        //health = 10;
        player = GameObject.Find("gracz");
        attackPlayer = false;
    }

    public NavMeshAgent Agent;
    public Vector3 oldDestAgent;
    public bool attackPlayer;

    void Update()
    {
        if (attackPlayer)
        {
            Agent.SetDestination(player.transform.position);
        }
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
            TourchLight(light, true);
            /*light.GetComponent<Light>().enabled = true;
            object halo = light.GetComponent("Halo");
            var haloInfo = halo.GetType().GetProperty("enabled");
            haloInfo.SetValue(halo, true, null);*/
        }
    }

    void KilledGost()
    {
        Destroy(gost);
    }

    public AudioSource dead;
    public AudioSource unVisible;
    public GameObject player;



    void OnTriggerEnter(Collider coll)
    {
        Debug.Log("Gost attack collider in: " + coll.gameObject.name);
        if (coll.gameObject.name == "book")
        { 
            health -= 5;
            Debug.Log("You attack gost");
            UpdateGost(transform.parent.gameObject);
        }
        else
        if (coll.gameObject.name == "gracz" && action < 1)
        {
            //oldDestAgent = Agent.destination;
            attackPlayer = true;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.name == "gracz" && attackPlayer)
        {
            attackPlayer = false;
            //Agent.SetDestination(oldDestAgent);
        }
    }

    private void TourchLight(GameObject tourchlight, bool active)
    {
        foreach (Transform light in tourchlight.transform)
        {
            light.gameObject.SetActive(active);
            /*light.GetComponent<Light>().enabled = true;
            object halo = light.GetComponent("Halo");
            var haloInfo = halo.GetType().GetProperty("enabled");
            haloInfo.SetValue(halo, true, null);*/
        }
    }

    public void UpdateGost(GameObject gost1)
    {
        Debug.Log(gost1.name);
        this.gost = gost1;
        if (health < 0)
        {
            //player.GetComponent<ImageCanvas>().image.gameObject.SetActive(false);
            Debug.Log("Killed gost");
            dead.Play();
            timer = 1.0f;
            action = 2;
            engine.gasts = engine.gasts + 1;
        }
        else
        {
            //gast.tick = -gast.tick;
            unVisible.Play();
            timer = 10.0f;
            action = 1;
            //gost.GetComponentInChildren<Renderer>().enabled = false;
            var renderers = this.gost.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)
            {
                r.enabled = !r.enabled;
            }

            //player.GetComponent<ImageCanvas>().image.gameObject.SetActive(false);

            attackPlayer = false;
            Agent.ResetPath();
        }
    }
}
