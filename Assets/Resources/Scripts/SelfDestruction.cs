using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruction : MonoBehaviour {

    public float aliveTime = 0.0f;

	// Use this for initialization
	void Start () 
    {
        Destroy(gameObject, aliveTime);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
