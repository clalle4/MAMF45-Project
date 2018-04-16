using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitListener : MonoBehaviour {
	public bool isWeapon = false;
	public bool isShield = false;
	float lastBlock;
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
		if (!isWeapon && !isShield) {
			if (contact.CompareTag ("Damaging")) {
            	gameObject.GetComponentsInParent<HPscript> () [0].takeDamage (contact.GetComponent<Weaponstats> ().getDamage ());
			}
		} else if (isWeapon) {
			if (contact.CompareTag ("Shield")) {
				gameObject.GetComponentsInParent<HPscript> () [0].stun ();
			}
		} else {
			if (contact.CompareTag ("Damaging")) {
				gameObject.GetComponentsInParent<HPscript> () [0].block (contact.GetComponent<Weaponstats> ().getDamage ());
			}
		}
	}
}