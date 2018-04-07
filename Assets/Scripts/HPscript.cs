using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPscript : MonoBehaviour
{

    private int health;
    // Use this for initialization
    void Start()
    {

        health = 20;
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
    public void takeDamage(int dmg)
    {

        health -= dmg;
        if (health <= 0)
        {
            PlayerlessEnemy pe = gameObject.GetComponent<PlayerlessEnemy>();
            if (pe != null)
            {
                pe.ragdoll(true);
            }
            else
            {
                Destroy(gameObject);
            }
            //dö
        }

    }
}
