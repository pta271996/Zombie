﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCarController : MonoBehaviour {

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
        transform.position -= Vector3.right * speed * Time.deltaTime;
    }
}
