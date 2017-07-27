using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float speed = 3.0f;
	public int damage = 1;

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

	void Move()
	{
		transform.position += Vector3.right * Time.deltaTime * speed;
	}

	public int getDamage()
	{
		return damage;
	}

	void OnTriggerEnter2D(Collider2D otherColl)
	{
		if (otherColl.tag == "zombie") 
		{
			Destroy(gameObject);
		}
	}
}
