using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitListener : MonoBehaviour {
	public bool isWeapon = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision coll)
    {
		GameObject contact = coll.gameObject;
		Debug.Log ("collided with: " + contact.gameObject.tag);
		if (!isWeapon) {
			//Debug.Log("Collided with " + coll.gameObject.name);
			if (contact.CompareTag ("Damaging")) {
            
				//Debug.Log(" at velocity: "+coll.gameObject.GetComponent<Valve.VR.InteractionSystem.VelocityEstimator>().GetVelocityEstimate());
				gameObject.GetComponentsInParent<HPscript> () [0].takeDamage (contact.GetComponent<Weaponstats> ().getDamage ());
			}
		} else {
			if (contact.CompareTag ("Shield")) {
				Debug.Log ("collided with shield: " + contact.gameObject.tag);
				gameObject.GetComponentsInParent<HPscript> () [0].stun();
			}
		}
    }
}
