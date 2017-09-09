using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidController : MonoBehaviour {

    public GameObject bloodSplatter;

	// Use this for initialization
	void Start () 
    {
        Instantiate(bloodSplatter, new Vector3(transform.position.x + Random.Range(1.25f, 1.5f), transform.position.y - 0.55f, 0.0f), bloodSplatter.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
