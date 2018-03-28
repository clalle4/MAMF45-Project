using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {
	public GameObject player;
	private PlayerScript _playerScript = null;
	private float lastCollision = -5;
	float moveTime = 5f;
	float inverseMoveTime ;
	Vector3 end;
	Rigidbody body;
	// Use this for initialization
	void Start () {
		end = player.transform.position;
		body = gameObject.GetComponent<Rigidbody>();
		inverseMoveTime = 1f / moveTime;
		//StartCoroutine(SmoothMovement());
	}
	
	// Update is called once per frame
	void Update () {
		end = player.transform.position;
	}

	void OnCollisionEnter (Collision col)
	{
		
		if((col.gameObject.name == "VRCamera" || col.gameObject.name == "Hand1"|| col.gameObject.name == "Hand2")&&Time.time-lastCollision > 5){
			Debug.Log ("Collided with: "+col.gameObject.name);
			if(col.gameObject.transform.parent.parent.name == "Player")
			{
				_playerScript = col.gameObject.transform.parent.parent.GetComponent<PlayerScript> ();
				if (_playerScript.hurt (-10)) {
					//Debug.Log ("DEAD");
				} else {
					//Debug.Log ("DAMAGE");
				}
				lastCollision = Time.time;
			}
		}


	}

	void FixedUpdate(){
		Vector3 diff = end - gameObject.transform.position;
		if (body.velocity.magnitude < 5f || diff.magnitude > 10f ) {
			body.AddForce (diff / 10, ForceMode.Impulse);
		}
	}

//	protected IEnumerator SmoothMovement(){
//		float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
//		while (sqrRemainingDistance > float.Epsilon) {
//			
//			//Vector3 newPosition = Vector3.MoveTowards (body.position, end, inverseMoveTime * Time.deltaTime);
//			//body.MovePosition (newPosition);
//			//sqrRemainingDistance = (transform.position - end).sqrMagnitude;
//			yield return null;
//		}
//	}
}
