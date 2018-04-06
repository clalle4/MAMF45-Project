using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nav : MonoBehaviour {
	Animator anim;
	public GameObject player;
	NavMeshAgent nav;
	EnemyScriptOld healthScr;// Use this for initialization

	void Start () {
		nav = GetComponent <NavMeshAgent> ();
		healthScr = GetComponent<EnemyScriptOld> ();
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		
		if (nav.enabled) {
			nav.destination = (player.transform.position);
			Debug.Log ("Active: "+gameObject.transform.position);
		}

			//gameObject.transform.LookAt (player.transform);
		//gameObject.transform.Rotate (0, 180, 0);
	}

	public void disabled(bool yes){
		if (yes) {
			nav.enabled = false;
			Debug.Log ("Disabled: "+gameObject.transform.position);
		}
	}
		
}
