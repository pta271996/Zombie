using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBulletC : SBullet
{
    public GameObject explosion;

    public float frequency = 20.0f;  // Speed of sine movement
    public float magnitude = 0.5f;   // Size of sine movement

    private Vector3 axis;
    private Vector3 pos;

	// Use this for initialization
	void Start () 
    {
        pos = transform.position;
        axis = transform.up;
	}
	
	// Update is called once per frame
	void Update () 
    {
        Move();
	}

    public override void Move()
    {
        pos += transform.right * Time.deltaTime * speed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if (otherColl.tag == "zombie"  || otherColl.tag == "zombie mom" || otherColl.tag == "car" || otherColl.tag == "bike" || otherColl.tag == "mirror" || otherColl.tag == "zombie head")
        {
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(gameObject);
        }     
    }
}
