using UnityEngine;
using System.Collections;

public class SBulletA : SBullet {

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
		

	//ham trigger thi tuy theo loai bullet ma ta se xu ly
	void OnTriggerEnter2D(Collider2D otherColl)
	{
		if (otherColl.tag == "zombie") 
		{
			Destroy(gameObject);
		}
	}
}
