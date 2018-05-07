using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Levelhandler : MonoBehaviour {
	public int nbrEnemiesStock;
	public GameObject enemy;
    public GameObject player;
    public GUIText dieText;

    // Use this for initialization
    void Start () {
        dieText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] enemies;
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		if (enemies.Length < 1 && nbrEnemiesStock != 0) {
			spawnEnemy ();
		}
        if (player.GetComponent<HPscript>().getHealth() <= 0)
        {
            Color darkRed = new Color(0.15f, 0f, 0f);
            dieText.text = "LELELELELELELELELELELELELELELEL";
            SteamVR_Fade.Start(darkRed, 3f);
        } 
	}

	void spawnEnemy(){
		nbrEnemiesStock--;
		Instantiate (enemy);
	}
}
