using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
	Animator animator;
	float deltaTime;
	private int health;
	public bool isRagdolled;
	bool runOnce;
	Vector3 enemyPos;

	GameObject player;
	Vector3 playerPos;

	// Use this for initialization
	//int runHash = Animator.StringToHash("Run");

		
	void Start () {
		runOnce = true;
		player = GameObject.FindGameObjectWithTag ("MainCamera");
		animator = gameObject.GetComponent<Animator> ();
		isRagdolled = false;
		health = 20;
		deltaTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		playerPos = player.transform.position;
		enemyPos = gameObject.transform.position;

		if (health <= 0) {
			Destroy (gameObject);
		}
		if (Time.time - deltaTime > 3 && runOnce) {
			Debug.Log ("HALLÅE");
			//animator.SetTrigger (runHash);
			animator.SetInteger("state", 1);
			runOnce = !runOnce;
		} else if (Vector3.Distance (playerPos, enemyPos) < 2) {
			animator.SetInteger ("state",2);
		}

	}

	void takeDamage() {
		

		if (health <= 0) {
			ragdoll (true);
			//dö
		}

	}


	void OnCollisionEnter (Collision coll) {
		GameObject contact = coll.gameObject;
		if (contact.CompareTag("Damaging")) {
			health = health -2;
			ragdoll (true);
			Debug.Log ("i took dmg");
		}
	}
	//turns ragdolling on/off
	void ragdoll (bool on){
		if (on) {
			Rigidbody[] rb = GetComponentsInChildren<Rigidbody> ();
			Animator a = GetComponent<Animator> ();
			Nav nav = GetComponent<Nav> ();
			a.enabled = false;
			nav.disabled (true);
			foreach(Rigidbody r in rb){
				r.useGravity = true;
				r.isKinematic = false;
			}
			rb [0].AddForce (new Vector3 (0, 100, 0));
		}
		isRagdolled = on;
	}
}