using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public int damage;
    public float speed;
    public GameObject hitEffect;


	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        Move();
	}

    void Move()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
    }

    public int getDamage()
    {
        return damage;
    }


    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if(otherColl.tag == "zombie")
        {
            if (hitEffect)
                Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
            Destroy(gameObject);
        }
    }


}
