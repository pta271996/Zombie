using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour {

    public float speed;

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

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if (otherColl.tag == "zombie" || otherColl.tag == "zombie mom" || otherColl.tag == "zombie shield" || otherColl.tag == "car");
            Destroy(gameObject);
    }
}
