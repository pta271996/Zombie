﻿using UnityEngine;
using System.Collections;

public class SBulletA : SBullet {

    public GameObject bloodHit;
    public GameObject shell;

	void Awake(){

	}
	// Use this for initialization
	void Start () 
	{
		//speed = 5.0f;
	}

	// Update is called once per frame
	void Update () 
	{
		Move ();
	}
		
	public override void Move()
	{
		base.Move ();
		//transform.position += Vector3.right * Time.deltaTime * speed;
	}
	//ham trigger thi tuy theo loai bullet ma ta se xu ly
	void OnTriggerEnter2D(Collider2D otherColl)
	{
		if (otherColl.tag == "zombie") 
		{         
            if (otherColl is BoxCollider2D)
            {
                if (otherColl.gameObject.GetComponent<SZombieFam>())
                    otherColl.gameObject.GetComponent<SZombieFam>().setDead();
            }
            else if (otherColl is CircleCollider2D)
            {
                if (otherColl.gameObject.GetComponent<SZombieFam>())
                    otherColl.gameObject.GetComponent<SZombieFam>().setDeadByHeadShot();
            }

            Instantiate(bloodHit, new Vector2(transform.position.x-0.15f,transform.position.y), bloodHit.transform.rotation);
			Destroy(gameObject);
		}

        if(otherColl.tag == "car")
        {
            Instantiate(shell, transform.position, shell.transform.rotation);
            if(otherColl.GetComponent<CarBodyController>())
            {
                otherColl.GetComponent<CarBodyController>().ShowSparkPS(transform.position);
            }
            Destroy(gameObject);
        }
	}
}
