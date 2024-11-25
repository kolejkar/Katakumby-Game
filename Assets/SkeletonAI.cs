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
    public bool hitted;

    public AudioSource bone;
    public AudioSource idle;

    // Start is called before the first frame update
    void Start()
    {
        health = 4;
        changeStatus = false;
        player = GameObject.Find("gracz");
        animation.clip = animation.GetClip("Idle");
        animation.Play();
        idle.Play();
        dead = false;
        hitted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            KilledSkeleton();
        }
        if (hitted)
        {
            HitSkeleton();
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
                    idle.Stop();
                    animation.Stop();
                    animation.clip = animation.GetClip("Walk");
                    changeStatus = false;
                    bone.Play();
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
                    idle.Stop();
                    bone.Stop();
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
                    bone.Stop();
                    animation.Stop();
                    animation.clip = animation.GetClip("Idle");
                    changeStatus = false;
                    idle.Play();
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
            idle.Stop();
            bone.Stop();
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

    void HitSkeleton()
    {
        if (changeStatus)
        {
            idle.Stop();
            bone.Stop();
            Debug.Log("Hitted skeleton.");
            animation.Stop();
            animation.clip = animation.GetClip("Hit");
            changeStatus = false;
            animation.Play();
        }
        if (!animation.isPlaying)
        {
            hitted = false;
            changeStatus = true;
        }
        Agent.ResetPath();
    }

    public void IsHitted()
    {
        changeStatus = true;
        hitted = true;
    }
}
