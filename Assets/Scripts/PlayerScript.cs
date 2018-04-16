using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerScript : MonoBehaviour {

	public BloodSplatterEffect bloodEffect;

	private int health;
	// Use this for initialization
	void Start () {
		//bloodEffect = GetComponent<BloodSplatterEffect> ();
		health = 20;
	}
	
	// Update is called once per frame
	void Update () {
		bloodEffect.BloodSplatter ();
	}

	public bool hurt(int damage){
		health += damage;
		return health <= 0;
	}
		
}
