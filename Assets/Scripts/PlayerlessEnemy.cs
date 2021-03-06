﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerlessEnemy : MonoBehaviour
{
    Animator animator;
    float lastTime;
    public bool isRagdolled;
    public GameObject spine;
    public GameObject hip;
    Vector3 spinePos;
    Vector3 hipPos;
    NavMeshAgent nav;
    int lastState;
    float nextAttackTime;

    //GameObject player;
    Vector3 playerPos;
    public float movementSpeed = 1;
    // Use this for initialization
    //int runHash = Animator.StringToHash("Run");


    void Start()
    {
        lastState = 0;
        nav = gameObject.GetComponent<NavMeshAgent>();
        //player = GameObject.FindGameObjectWithTag ("MainCamera");
        animator = gameObject.GetComponent<Animator>();
        isRagdolled = false;
        lastTime = Time.time;
        nextAttackTime = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.LookAt(playerPos);
        //Debug.Log("State: "+animator.GetInteger("state"));
        //Debug.Log("Time: " + Time.time + " AttackTime: " + nextAttackTime + " LastTime: " + lastTime);
        playerPos = new Vector3(0f, 1.3f, -1.5f); //hårdkod, byt ut mot nedre rad för HMD
        //playerPos = player.transform.position;
        spinePos = spine.transform.position;
        hipPos = hip.transform.position;

       
        if (Time.time - lastTime > 3 && Vector3.Distance(spinePos, playerPos)> 3 && animator.GetInteger("state")!=1)
        {
            lastTime = Time.time;
            setAnimation(1);
        } else if (Vector3.Distance (playerPos, spinePos) < 2.5f && (animator.GetInteger("state") == 0 || animator.GetInteger("state") == 1)) {
            setAnimation(2);
        }
        if(animator.GetInteger("state") == 1 && Time.time - lastTime > 0.6)
        {
            nav.SetDestination(playerPos);
        }else if (animator.GetInteger("state") == 2)
        {
            if(lastState != 2)
            {
                nav.SetDestination(new Vector3(1.0f, transform.position.y, playerPos.z + 2f));
                lastState = 2;
            }else if(Vector3.Distance(nav.destination, transform.position)< 0.1)
            {
                setAnimation(3);
            }
        }else if (animator.GetInteger("state") == 3)
        {
            if (lastState != 3)
            {
                nav.SetDestination(new Vector3(-1.0f, transform.position.y, playerPos.z+2f));
                lastState = 3;
            }else if (Vector3.Distance(nav.destination, transform.position) < 0.1)
            {
                setAnimation(2);
            }
        }
        if (Time.time > nextAttackTime && animator.GetInteger("state")!=4)
        {
            setAnimation(4);
            lastTime = Time.time;
            nextAttackTime +=4;
        }
        if (animator.GetInteger("state") == 4 && Time.time > lastTime+2)
        {
            setAnimation(2);
        }

    }

   

    void setAnimation(int ani)
    {
        lastState = animator.GetInteger("state");
        //nav.enabled = ani==1;
        if(ani ==2 || ani == 3)
        {
            nextAttackTime = Time.time + Random.Range(2,4);
            nav.stoppingDistance = 0;
            nav.speed = 1f;
            nav.angularSpeed = 0;
        }
        else if(ani<2)
        {
            nav.stoppingDistance = 2.4f;
            nav.speed = 3.5f;
            nav.angularSpeed = 120;
        } else if (ani == 4) 
        {

        }
        animator.SetInteger("state", ani);
    }

    
    //turns ragdolling on/off, not yet implemented properly.
    public void ragdoll(bool on)
    {
        if (on)
        {
            Rigidbody[] rb = GetComponentsInChildren<Rigidbody>();
            animator.enabled = false;
            nav.enabled = false;
            foreach (Rigidbody r in rb)
            {
                r.useGravity = true;
                r.isKinematic = false;
            }
        }
        isRagdolled = on;
    }
}