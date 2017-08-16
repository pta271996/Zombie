using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenMirrorController : MonoBehaviour {

    public Rigidbody2D myRB;
    public float forceX, forceY, angle;

	// Use this for initialization
	void Start () 
    {
        myRB.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
        myRB.AddTorque(angle);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
