using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBikeController : MonoBehaviour {

    public float speed;
    private bool isDead;

	// Use this for initialization
	void Start () 
    {
        isDead = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!isDead)
            Move();
	}

    void Move()
    {
        transform.position -= Vector3.right * speed * Time.deltaTime;
    }
}
