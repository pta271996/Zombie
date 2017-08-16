using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShellController : MonoBehaviour {

    public Rigidbody2D myRB;

	// Use this for initialization
	void Start () 
    {
        myRB.AddForce(new Vector2(-6.0f, 3.5f), ForceMode2D.Impulse);
        myRB.AddTorque(45);
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
}
