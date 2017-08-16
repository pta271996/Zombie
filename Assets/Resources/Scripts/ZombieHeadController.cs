using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHeadController : MonoBehaviour {

    public Rigidbody2D myRB;
    public float forceX, forceY, angle;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void RemoveHead()
    {
        myRB.gravityScale = 1.0f;
        myRB.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
        myRB.AddTorque(angle);
    }

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if(otherColl.tag == "bullet")
        {
            RemoveHead();
            transform.root.GetComponent<ZombieCarController>().makeDead();
            Destroy(gameObject, 1.5f);
        }
    }
}
