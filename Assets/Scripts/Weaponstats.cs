using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponstats : MonoBehaviour {
    public float damage = 10f;
    public bool complexDamage = false;
    public bool playerWeapon = false;
    public bool playerShield = false;
    public Text hpText;
	// Use this for initialization




	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

	public void detach() {
		gameObject.transform.parent = null;
	}

    public void deactivateWeapon ()
    {
        damage = 0;
    }

    public float getDamage()
    {
        if (!complexDamage)
        {
            return damage;
        }
        else if (playerWeapon && complexDamage)
        {
            //Vector3 vel = gameObject.GetComponent<Rigidbody>().velocity;
			Vector3 vel = gameObject.GetComponent<Valve.VR.InteractionSystem.VelocityEstimator>().GetVelocityEstimate();
			return Mathf.Sqrt(Mathf.Pow(vel.x, 2f) + Mathf.Pow(vel.y, 2f) + Mathf.Pow(vel.z, 2f)) * damage;
        	
		} else
        {
            return 0f;
        }
    }
}
