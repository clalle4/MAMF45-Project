using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision coll)
    {
        GameObject contact = coll.gameObject;
        //Debug.Log("Collided with " + coll.gameObject.name);
        if (contact.CompareTag("Damaging"))
        {
            
        //Debug.Log(" at velocity: "+coll.gameObject.GetComponent<Rigidbody>().velocity);
            gameObject.GetComponentsInParent<HPscript>()[0].takeDamage(contact.GetComponent<Weaponstats>().getDamage());
        }
    }
}
