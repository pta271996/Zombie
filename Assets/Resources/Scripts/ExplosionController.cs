using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        Invoke("RemoveExplosionArea", 0.65f);
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if (otherColl.tag == "zombie")
        {           
            if (otherColl.gameObject.GetComponent<SZombieFam>())
                otherColl.gameObject.GetComponent<SZombieFam>().setDeadByBoom();           
        }
        if (otherColl.tag == "car" || otherColl.tag == "mirror")
        {          
            otherColl.gameObject.transform.root.GetComponent<ZombieCarController>().makeDeadByBoom();
        }
        if (otherColl.tag == "bike")
        {
            otherColl.gameObject.transform.root.GetComponent<ZombieBikeController>().makeDeadByBoom();
        }
        if (otherColl.tag == "mower")
        {
            otherColl.gameObject.transform.root.GetComponent<ZombieMowerController>().makeDeadByBoom();
        }
    }

    void RemoveExplosionArea()
    {
        Destroy(gameObject.GetComponent<CircleCollider2D>());
    }
}
