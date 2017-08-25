using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMowerController : MonoBehaviour {

    public float speed;
    public Animator myAnim;
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
