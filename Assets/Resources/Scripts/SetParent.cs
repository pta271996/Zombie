using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour {

    public Transform bullet;

	// Use this for initialization
	void Start () 
    {
        transform.parent = bullet;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
