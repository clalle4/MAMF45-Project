using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerlessEnemy : MonoBehaviour
{
    Animator animator;
    float lastTime;
    private int health;
    public bool isRagdolled;
    bool runOnce;
    public GameObject spine;
    public GameObject hip;
    Vector3 spinePos;
    Vector3 hipPos;
    NavMeshAgent nav;
    int currentAni;

    //GameObject player;
    Vector3 playerPos;
    public float movementSpeed = 0.001f;
    // Use this for initialization
    //int runHash = Animator.StringToHash("Run");


    void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
        runOnce = true;
        //player = GameObject.FindGameObjectWithTag ("MainCamera");
        animator = gameObject.GetComponent<Animator>();
        isRagdolled = false;
        health = 20;
        lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = new Vector3((float)0.64, (float)1.130198, (float)-1.94); //hård kod, byt ut mot nedre rad för HMD
        //playerPos = player.transform.position;
        spinePos = spine.transform.position;
        hipPos = hip.transform.position;   

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (Time.time - lastTime > 3 && runOnce)
        {
            lastTime = Time.time;
            setAnimation(1);
            runOnce = !runOnce;
        } else if (Vector3.Distance (playerPos, spinePos) < 2) {
            setAnimation(2);
        }
        if(currentAni == 1 && Time.time - lastTime > 0.6)
        {   
            nav.SetDestination(playerPos);
        }
        if(currentAni == 2){
        Vector3 direction = (new Vector3(1,0,0)).normalized;
        gameObject.GetComponent<Rigidbody>().MovePosition(transform.position + direction * movementSpeed * Time.deltaTime);
        }
    }

    void takeDamage()
    {


        if (health <= 0)
        {
            ragdoll(true);
            //dö
        }

    }

    void setAnimation(int ani)
    {
        currentAni = ani;
        if(ani != 1 && ani != 2) {
            nav.enabled = false;
        }
        if(ani == 2)
        {
            //strafe mechanics
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            //gameObject.GetComponent<Rigidbody>().MovePosition(hipPos+new Vector3(1,0,0));
        }
         
        animator.SetInteger("state", ani);
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject contact = coll.gameObject;
        if (contact.CompareTag("Damaging"))
        {
            health = health - 2;
            ragdoll(true);
            Debug.Log("i took dmg");
        }
    }
    //turns ragdolling on/off
    void ragdoll(bool on)
    {
        if (on)
        {
            Rigidbody[] rb = GetComponentsInChildren<Rigidbody>();
            Animator a = GetComponent<Animator>();
            Nav nav = GetComponent<Nav>();
            a.enabled = false;
            nav.disabled(true);
            foreach (Rigidbody r in rb)
            {
                r.useGravity = true;
                r.isKinematic = false;
            }
            rb[0].AddForce(new Vector3(0, 100, 0));
        }
        isRagdolled = on;
    }
}