using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {

    public Rigidbody2D myRB;
    public float forceX, forceY, angle;
    private bool isDead;


	// Use this for initialization
	void Start () 
    {
        isDead = false;
        //GetComponent<SpriteRenderer>().material.color = Color.Lerp(GetComponent<SpriteRenderer>().material.color, new Color(255.0f, 0.0f, 0.0f, 255.0f), 2.5f * Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (isDead && GetComponent<SpriteRenderer>())
            GetComponent<SpriteRenderer>().material.color = Color.Lerp(GetComponent<SpriteRenderer>().material.color, new Color(1.0f, 0.0f, 0.0f, 1.0f), 1.5f * Time.deltaTime);
	}

    public void Explode()
    {
        isDead = true;   
        myRB.gravityScale = 1.0f;
        myRB.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
        myRB.AddTorque(angle);
    }
}
