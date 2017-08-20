using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingZombieController : MonoBehaviour {

    public float dropTime;
    public Transform parachutePos;
    public GameObject parachute;
    public GameObject zombieFam5;

	// Use this for initialization
	void Start () 
    {
        Invoke("Land", dropTime);
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void Land()
    {
        Instantiate(parachute, parachutePos.position, parachute.transform.rotation);
        Instantiate(zombieFam5, transform.position, zombieFam5.transform.rotation);
        Destroy(gameObject);
    }
}
