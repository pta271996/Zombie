using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {

    public GameObject bigExplosion;

	// Use this for initialization
	void Start () 
    {       
        Invoke("Explode", 1.85f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Explode()
    {
        Instantiate(bigExplosion, transform.position, bigExplosion.transform.rotation);
        Destroy(gameObject);
    }

   
}
