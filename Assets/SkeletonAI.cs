using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonAI : MonoBehaviour
{
    public int health = 0;

    public NavMeshAgent Agent;
    public Vector3 oldDestAgent;

    public Animation animation;

    public GameObject player;

    public bool attackPlayer;
    public bool changeStatus;
    public bool hitPlayer;
    public bool dead;

    // Start is called before the first frame update
    void Start()
    {
        health = 4;
        changeStatus = false;
        player = GameObject.Find("gracz");
        animation.clip = animation.GetClip("Idle");
        animation.Play();
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            KilledSkeleton();
        }
        else
        {
            if (health < 1)
            {
                Debug.Log("Killed skeleton.");
                changeStatus = true;
                dead = true;
            }
            if (attackPlayer)
            {
                if (changeStatus)
                {
                    animation.Stop();
                    animation.clip = animation.GetClip("Walk");
                    changeStatus = false;
                }
                if (!animation.isPlaying)
                {
                    animation.Play();
                }
                Agent.SetDestination(player.transform.position);
            }
            else
            if (hitPlayer)
            {
                if (changeStatus)
                {
                    animation.Stop();
                    animation.clip = animation.GetClip("Attack");
                    changeStatus = false;
                }
                if (!animation.isPlaying)
                {
                    animation.Play();
                }
                Agent.ResetPath();
            }
            else
            {
                if (changeStatus)
                {
                    animation.Stop();
                    animation.clip = animation.GetClip("Idle");
                    changeStatus = false;
                }
                if (!animation.isPlaying)
                {
                    animation.Play();
                }
                Agent.ResetPath();
            }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name == "gracz")
        {
            attackPlayer = true;
            changeStatus = true;
        }

    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.name == "gracz" && attackPlayer)
        {
            attackPlayer = false;
            changeStatus = true;
        }
    }

    void KilledSkeleton()
    {
        if (changeStatus)
        {
            animation.Stop();
            animation.clip = animation.GetClip("Dead");
            changeStatus = false;
            animation.Play();
        }
        if (!animation.isPlaying)
        {
            Destroy(gameObject);
        }        
    }
}
