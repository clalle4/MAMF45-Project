using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nav : MonoBehaviour {
	Animator anim;
	public GameObject player;
	NavMeshAgent nav;
	EnemyScript healthScr;// Use this for initialization

	void Start () {
		nav = GetComponent <NavMeshAgent> ();
		healthScr = GetComponent<EnemyScript> ();
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		nav.destination = (player.transform.position);
		//gameObject.transform.LookAt (player.transform);
		//gameObject.transform.Rotate (0, 180, 0);
	}

	public void switchMode(){
		
	}
		
}
