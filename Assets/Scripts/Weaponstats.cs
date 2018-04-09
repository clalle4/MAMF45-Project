using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponstats : MonoBehaviour {
    public float damage = 10f;
    public bool complexDamage = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public float getDamage()
    {
        if (!complexDamage)
        {
            return damage;
        }
        else
        {
            Vector3 vel = gameObject.GetComponent<Rigidbody>().velocity;
            return Mathf.Sqrt(Mathf.Pow(vel.x, 2f) + Mathf.Pow(vel.y, 2f) + Mathf.Pow(vel.z, 2f)) * damage;
        }
    }
}
