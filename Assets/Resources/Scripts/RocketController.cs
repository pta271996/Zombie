using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour {

    public float speed;
    public GameObject explosion;

	// Use this for initialization
	void Start () {
		
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

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if (otherColl.tag == "zombie" || otherColl.tag == "zombie mom" || otherColl.tag == "car" || otherColl.tag == "bike" || otherColl.tag == "mirror" || otherColl.tag == "zombie head")
        {
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(gameObject);
        }
    }
}
