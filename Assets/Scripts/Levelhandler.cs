using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelhandler : MonoBehaviour {
	public int nbrEnemiesStock;
	public GameObject enemy;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] enemies;
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		if (enemies.Length < 1 && nbrEnemiesStock != 0) {
			spawnEnemy ();
		}
	}
	void spawnEnemy(){
		nbrEnemiesStock--;
		Instantiate (enemy);
	}
}
