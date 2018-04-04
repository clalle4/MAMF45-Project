using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getBoned : MonoBehaviour {
	private EnemyScript[] ES;
	private Vector3 position;
	private bool once;
	// Use this for initialization
	void Start () {
		ES = GetComponentsInParent<EnemyScript> ();
	}

	// Update is called once per frame
	void Update () {
		if (!ES [0].isRagdolled) {
			once = true;
			position = gameObject.transform.position;
		} else if(once){
			gameObject.transform.position = position;
			once = false;
		}
	}
}
