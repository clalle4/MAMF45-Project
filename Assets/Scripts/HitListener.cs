using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitListener : MonoBehaviour {
	public bool isWeapon = false;
	public bool isShield = false;
    private float iframetime;
    private Color darkRed = new Color(0.15f, 0f, 0f);
    private Color transparent = new Color(0, 0, 0, 0);

    // Use this for initialization
    void Start () {
        iframetime = Time.time;
    }
	
	// Update is called once per framew
	void Update () {
		
	}

    void OnCollisionEnter(Collision coll)
	{
		GameObject contact = coll.gameObject;
		Debug.Log (gameObject.tag + " collided with: " + contact.gameObject.tag);
		if (!isWeapon && !isShield) {
            Debug.Log(contact.tag);
			if (contact.CompareTag ("Damaging")) {
            	gameObject.GetComponentsInParent<HPscript> () [0].takeDamage (contact.GetComponent<Weaponstats> ().getDamage ());
			}
		} else if (isWeapon) {
            if (contact.CompareTag("Shield")) {
                gameObject.GetComponentsInParent<HPscript>()[0].stun();
                iframetime = Time.time;
            }
            else if (contact.CompareTag("Player") && iframetime < Time.time - 1f)
            {
                iframetime = Time.time;
                Debug.Log("i took dmg from enemy lel");
                SteamVR_Fade.Start(darkRed, 0.75f);
                contact.GetComponentsInParent<HPscript>()[0].takeDamage(gameObject.GetComponent<Weaponstats>().getDamage());
                Invoke("fadeToTransparent", 0.25f);
            }
        } else if (isShield){
			if (contact.CompareTag ("Damaging")) {
				gameObject.GetComponentsInParent<HPscript> () [0].block (contact.GetComponent<Weaponstats> ().getDamage ());
			}
		}
	}

    public void fadeToTransparent()
    {
        SteamVR_Fade.Start(transparent, 0.5f);
    }

}