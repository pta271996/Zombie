using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour {

    public Rigidbody2D myRB;
    public GameObject explosion;
    public float forceX;
    public float forceY;

	// Use this for initialization
	void Start () 
    {
        Move();
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void Move()
    {
        myRB.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
        myRB.AddTorque(-5);
    }

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if(otherColl.tag == "zombie")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if(otherColl.tag == "car" || otherColl.tag == "mirror")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            //otherColl.gameObject.transform.root.GetComponent<ZombieCarController>().makeDeadByBoom();
            Destroy(gameObject);
        }
    }
}
