using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPscript : MonoBehaviour
{

    private float health;
    // Use this for initialization
    void Start()
    {

        health = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            //gameObject.GetComponent<PlayerlessEnemy>().ragdoll(true);
        }
    }
    public void takeDamage(float dmg)
    {

        health -= dmg;
        Enemy e = gameObject.GetComponent<Enemy>();
        if (e != null)
        {
            e.setAnimation(5);
            Debug.Log("ow! "+dmg+" damage!");
        }
        if (health <= 0)
        {
            if (e != null)
            {
                e.ragdoll(true);
            }
            else
            {
                Destroy(gameObject);
            }
            //dö
        }

    }
}
