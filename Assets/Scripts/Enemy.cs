
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	Valve.VR.InteractionSystem.Throwable[] throws;
	Animator animator;
    float lastTime;
    public GameObject spine;
    public GameObject hip;
    Vector3 spinePos;
    Vector3 hipPos;
    NavMeshAgent nav;
    int lastState;
	bool isRagdolled;
    float nextAttackTime;

    GameObject player;
    Vector3 playerPos;
    public float movementSpeed = 1;

    // Use this for initialization
    void Start()
    {
		throws = gameObject.GetComponents<Valve.VR.InteractionSystem.Throwable> ();
		foreach (Valve.VR.InteractionSystem.Throwable t in throws){
			t.enabled = false;
		}
		isRagdolled = false;
        lastState = 0;
        nav = gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag ("MainCamera");
        animator = gameObject.GetComponent<Animator>();
        lastTime = Time.time;
        nextAttackTime = 1000;
    }

    // Update is called once per frame
    void Update()
    {
		if (!isRagdolled) {
			//Debug.Log("State: "+animator.GetInteger("state"));
			//Debug.Log("Time: " + Time.time + " AttackTime: " + nextAttackTime + " LastTime: " + lastTime);
			//playerPos = new Vector3(0f, 1.3f, -1.5f); //hårdkod, byt ut mot nedre rad för HMD
			playerPos = player.transform.position;
			transform.LookAt (playerPos - new Vector3 (0, playerPos.y - 1.8f, 0));
			spinePos = spine.transform.position;
			hipPos = hip.transform.position;
			//Debug.Log ("Time: " + Time.time + " LastTime: " + lastTime);
			if ((animator.GetInteger ("state") == 5 && Time.time > lastTime + 0.9f)||(animator.GetInteger ("state") == 6 && Time.time > lastTime + 0.18f)||((animator.GetInteger ("state") == 7 || (animator.GetInteger ("state") == 8)) && Time.time > lastTime+0.3f)) {
				setAnimation (2);
			}
			if (animator.GetInteger ("state") == 7 && lastState != 7) {
				lastState = 7;
				nav.SetDestination (spinePos - new Vector3 (0, 0, -0.5f));
			} else if(animator.GetInteger ("state") == 8 && lastState != 8){
				lastState = 8;
				nav.SetDestination (spinePos - new Vector3 (0, 0, -1f));
			}

			if (Time.time - lastTime > 3 && Vector3.Distance (spinePos, playerPos) > 3 && animator.GetInteger ("state") != 1) {
				lastTime = Time.time;
				setAnimation (1);
			} else if (Vector3.Distance (playerPos, spinePos) < 2.5f && (animator.GetInteger ("state") == 0 || animator.GetInteger ("state") == 1)) {
				setAnimation (2);
			}
			if (animator.GetInteger ("state") == 1 && Time.time - lastTime > 0.6) {
				nav.SetDestination (playerPos);
			} else if (animator.GetInteger ("state") == 2) {
				if (lastState != 2) {
					nav.SetDestination (new Vector3 (1.0f, transform.position.y, playerPos.z + 2f));
					lastState = 2;
				} else if (Vector3.Distance (nav.destination, transform.position) < 0.1) {
					setAnimation (3);
				}
			} else if (animator.GetInteger ("state") == 3) {
				if (lastState != 3) {
					nav.SetDestination (new Vector3 (-1.0f, transform.position.y, playerPos.z + 2f));
					lastState = 3;
				} else if (Vector3.Distance (nav.destination, transform.position) < 0.1) {
					setAnimation (2);
				}
			}
			if (Time.time > nextAttackTime && animator.GetInteger ("state") != 4) {
				setAnimation (4);
			}
			if (animator.GetInteger ("state") == 4 && Time.time > lastTime + 2) {
				setAnimation (2);
			}
		}
    }



    public void setAnimation(int ani)
    {
		//+Debug.Log ("Animation: " +ani+ " Time: "+Time.time);
        lastState = animator.GetInteger("state");
        //nav.enabled = ani==1;
		if (ani == 2 || ani == 3) {
			nextAttackTime = Time.time + Random.Range (1, 3);
			nav.stoppingDistance = 0;
			nav.speed = 1f;
			nav.angularSpeed = 0;
		} else if (ani < 2) {
			nav.stoppingDistance = 2.4f;
			nav.speed = 3.5f;
			nav.angularSpeed = 120;
		} else if (ani == 4) {
			lastTime = Time.time;
			nextAttackTime += 10;
		} else if (ani == 5) {
			nav.stoppingDistance = 0;
			nav.speed = 0;
			nav.angularSpeed = 0;
			lastTime = Time.time;
		} else if (ani == 6) {
			nav.stoppingDistance = 0;
			nav.speed = 0;
			nav.angularSpeed = 0;
			lastTime = Time.time;
		} else if (ani == 7) {
			nav.stoppingDistance = 0;
			nav.speed = 5f;
			nav.angularSpeed = 0;
		} else if (ani == 8) {
			nav.stoppingDistance = 0;
			nav.speed = 5f;
			nav.angularSpeed = 0;
			lastTime = Time.time;
		}
        animator.SetInteger("state", ani);
    }

    public void ragdoll()
    {
            Rigidbody[] rb = GetComponentsInChildren<Rigidbody>();
            animator.enabled = false;
            nav.enabled = false;
			Weaponstats [] sw;
			sw = GetComponentsInChildren<Weaponstats> ();
			foreach (Weaponstats w in sw) {
				w.detach ();
			}
            foreach (Rigidbody r in rb)
            {
                r.useGravity = true;
                r.isKinematic = false;
            }
		//gameObject.transform.GetComponent<Rigidbody> ().AddForce (spine.transform.position + new Vector3 (0, 100, -10000)); //(1000f, spine.transform.position+new Vector3(0,0,-1), 5f,1f);
		foreach (Valve.VR.InteractionSystem.Throwable t in throws){
			t.enabled = true;
		}
		isRagdolled = true;
		gameObject.tag = "Dead";
    	}
}