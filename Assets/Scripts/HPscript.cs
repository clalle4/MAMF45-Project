using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPscript : MonoBehaviour
{

    private float health;
    private bool alive;
	float lastBlock;
    public bool isPlayer;
    public AudioSource aS;

    // Use this for initialization
    void Start()
    {
		lastBlock = 0f;
        health = 20f;
        alive = true;
        aS = GetComponent<AudioSource>();
    }

    public float getHealth()
    {
        return health;
    }

    // Update is called once per frame
    void Update()
    {
    }
	public void takeDamage(float dmg)
    {
        if (!isPlayer)
        {
            if (Time.time > lastBlock + 1.0f)
            {
                Enemy e = gameObject.GetComponent<Enemy>();
                health -= dmg;
                if (e != null)
                {
                    if (dmg * 10 > health)
                    {
                        e.setAnimation(5);
                    }
                    //Debug.Log("ow! " + dmg + " damage!");
                }
                if (health <= 0 && alive)
                {
                    alive = false;
                    Weaponstats[] w = gameObject.GetComponentsInChildren<Weaponstats>();
                    foreach (Weaponstats we in w)
                    {
                        we.deactivateWeapon();
                    }
                    if (e != null)
                    {
                        //Debug.Log("am ragdoll now");
                        e.ragdoll();
                    }
                    else
                    {
                        //Debug.Log("Am destroyed nowz. am sad.");
                        Destroy(gameObject);
                    }
                }
            }
        } else {
            health -= dmg;
            Debug.Log("Playerhealth is: " + health);
            if (health <= 0)
            {
                Debug.Log("player dead. am not sad.");
            }
            //Debug.Log("ow! " + dmg + " damage! Im the player lel!");
        }
    }
	public void stun(){
		Enemy e = gameObject.GetComponent<Enemy>();
		if (e != null) {
            aS.Play();
            if (e.getAnimation() == 4)
            {
			e.setAnimation (6);
            } else if (e.getAnimation() == 9)
            {
                e.setAnimation(10);
            } else if (e.getAnimation() == 11)
            {
                e.setAnimation(12);
            }
        }
	}
    
	public void block(float f) {
		lastBlock = Time.time;
        aS.Play();
		Enemy e = gameObject.GetComponent<Enemy> ();
		if (e != null) {
			if (f > 5f) {
				e.setAnimation (7);
			}
			else {
				e.setAnimation(8);
			}
		}
	}
}
