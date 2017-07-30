using UnityEngine;
using System.Collections;

public class SBulletA : SBullet {

    public GameObject bloodHit;

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
            Instantiate(bloodHit, new Vector2(transform.position.x-0.15f,transform.position.y), bloodHit.transform.rotation);
			Destroy(gameObject);
		}
	}
}
