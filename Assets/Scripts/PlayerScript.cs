using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	private int health;
	// Use this for initialization
	void Start () {
		health = 20;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public bool hurt(int damage){
		health += damage;
		return health <= 0;
	}
		
}
