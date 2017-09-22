using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour {

    public Rigidbody2D myRB;
    public GameObject hitEffect;
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
        myRB.AddTorque(120);
    }

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if (otherColl.tag == "zombie" || otherColl.tag == "zombie mom" || otherColl.tag == "zombie shield")
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

        if (otherColl.tag == "car" || otherColl.tag == "mirror" || otherColl.tag == "bike" || otherColl.tag == "mower")
        {
            Destroy(gameObject);
        }
    }
}
