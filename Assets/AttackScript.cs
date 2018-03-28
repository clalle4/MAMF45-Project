using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {
	public GameObject player;
	private PlayerScript _playerScript = null;
	private float lastCollision = -5;
	private float moveTime = 0.f;
	private float inverseMoveTime = 1f / moveTime;
	Rigidbody body = gameObject.GetComponent<Rigidbody>;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(SmoothMovement(player.transform.position));
	}

	void OnCollisionEnter (Collision col)
	{
		
		if((col.gameObject.name == "VRCamera" || col.gameObject.name == "Hand1"|| col.gameObject.name == "Hand2")&&Time.time-lastCollision > 5){
			Debug.Log ("Collided with: "+col.gameObject.name);
			if(col.gameObject.transform.parent.parent.name == "Player")
			{
				_playerScript = col.gameObject.transform.parent.parent.GetComponent<PlayerScript> ();
				if (_playerScript.hurt (-10)) {
					Debug.Log ("DEAD");
				} else {
					Debug.Log ("DAMAGE");
				}
				lastCollision = Time.time;
			}
		}


	}
	IEnumerator wait(int time){
		yield return new WaitForSeconds (time);
	}
	protected bool SmoothMovement(int x, int y, int z){
		Vector3 end = new Vector3(x,y,z);
		float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

		while (sqrRemainingDistance > float.Epsilon) {
			Vector3 newPosition = Vector3.MoveTowards (body.position, end, inverseMoveTime * Time.deltaTime);
			body.MovePosition (newPosition);
			sqrRemainingDistance = (transform.position - end).sqrMagnitude;
			yield return null;
		}
	}
}
