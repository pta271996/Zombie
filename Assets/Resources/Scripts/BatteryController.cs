﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour {

    public GameObject explosion;
    public Rigidbody2D myRB;
    public float forceX;
    public float forceY;


	// Use this for initialization
	void Start () 
    {
        Move();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Move()
    {
        myRB.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
        myRB.AddTorque(2);
    }

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if (otherColl.tag == "zombie")
        {
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            otherColl.gameObject.GetComponent<SZombieFam>().setDead();
            otherColl.gameObject.GetComponent<SZombieFam>().makeDead();
            Destroy(gameObject);
        }
        if (otherColl.tag == "car" || otherColl.tag == "mirror" || otherColl.tag == "bike" || otherColl.tag == "mower")
        {
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(gameObject);
        }        
    }
}