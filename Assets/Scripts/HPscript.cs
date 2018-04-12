using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPscript : MonoBehaviour
{

    private float health;
    private bool alive;

    // Use this for initialization
    void Start()
    {

        health = 20f;
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
	public void takeDamage(float dmg)
    {
		Enemy e = gameObject.GetComponent<Enemy>();
        health -= dmg;
        if (e != null)
		{ 
			if (dmg * 10 > health) {	
				e.setAnimation (5);
			}
			Debug.Log ("ow! " + dmg + " damage!");
		}
        if (health <= 0 && alive)
        {
            alive = false;
            if (e != null)
            {
				Debug.Log ("am ragdoll now");
                e.ragdoll();
            }
            else
            {
				Debug.Log ("Am destroyed nowz. am sad.");
                Destroy(gameObject);
            }
        }

    }
	public void stun(){
		Enemy e = gameObject.GetComponent<Enemy>();
		if (e != null) {
			e.setAnimation (6);
		}
	}
}
