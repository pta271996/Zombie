using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRay : SBullet {

	public float angle;

	public GameObject bloodHit;

	// Use this for initialization
	void Start () 
	{
		var rotationVector = transform.rotation.eulerAngles;
		rotationVector.z = angle;
		transform.rotation = Quaternion.Euler(rotationVector);
	}

	// Update is called once per frame
	void Update () 
	{
		Move();
	}

	public override void Move()
	{
		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3(0, speed * Time.deltaTime, 0);
		pos += transform.rotation * velocity;
		transform.position = pos;
	}

	void OnTriggerEnter2D(Collider2D otherColl)
	{
		if (otherColl.tag == "zombie")
		{
			Instantiate(bloodHit, new Vector2(transform.position.x - 0.15f, transform.position.y), bloodHit.transform.rotation);
			Destroy(gameObject);
		}
	}


}
