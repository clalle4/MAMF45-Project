using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPscript : MonoBehaviour {

    private int health;
    // Use this for initialization
    void Start () {
		
    health = 20;
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Destroy(gameObject);
            //gameObject.GetComponent<PlayerlessEnemy>().ragdoll(true);
        }
    }
    void takeDamage()
    {


        if (health <= 0)
        {
            
            //dö
        }

    }
    void OnCollisionEnter(Collision coll)
    {
        GameObject contact = coll.gameObject;
        if (contact.CompareTag("Damaging"))
        {
            health = health - 2;
            Debug.Log("i took dmg");
        }
    }
}
