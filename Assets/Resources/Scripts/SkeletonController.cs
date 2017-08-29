using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour {

    public GameObject shockWave;

	// Use this for initialization
	void Start () 
    {
        Instantiate(shockWave, new Vector3(transform.position.x, transform.position.y - 0.12f, transform.position.z), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
}
