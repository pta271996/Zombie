using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour {

    public GameObject explosion;
    public Rigidbody2D myRB;
    public float forceX;
    public float forceY;


	// Use this for initialization
	void Start () 
    {
        Move();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Move()
    {
        myRB.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
        myRB.AddTorque(2);
    }

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if (otherColl.tag == "zombie")
        {
            GameObject soundManager = GameObject.Find("SoundManager");
            soundManager.GetComponent<SoundsManager>().playBulletExplodeSound();
            Instantiate(explosion, transform.position, explosion.transform.rotation);
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
        if (otherColl.tag == "car" || otherColl.tag == "mirror" || otherColl.tag == "bike" || otherColl.tag == "mower" || otherColl.tag == "zombie mom" || otherColl.tag == "zombie shield")
        {
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(gameObject);
        }        
    }
}
