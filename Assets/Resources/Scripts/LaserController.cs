using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

    public GameObject BloodHit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if (otherColl.tag == "zombie")
        {
            Instantiate(BloodHit, otherColl.transform.position, BloodHit.transform.rotation);
            if (otherColl.gameObject.GetComponent<SZombieFam>())
            {
                otherColl.gameObject.GetComponent<SZombieFam>().setDead();
                otherColl.gameObject.GetComponent<SZombieFam>().makeDead();
            }
            else if (otherColl.gameObject.GetComponent<SZombieJump>())
            {
                otherColl.gameObject.GetComponent<SZombieJump>().setDead();
                otherColl.gameObject.GetComponent<SZombieJump>().makeDead();
            }
            Destroy(gameObject);
        }
        if (otherColl.tag == "car" || otherColl.tag == "mirror" || otherColl.tag == "bike" || otherColl.tag == "mower")
        {
            Destroy(gameObject);
        }
    }
}
