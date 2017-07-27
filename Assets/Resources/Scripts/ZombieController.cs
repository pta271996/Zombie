using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

	public float speed = 4.0f;
	public int health = 2;
	public float attackTime = 1.5f;
	public Animator myAnim;

	private bool isAttacking;
	private bool isDead;


	// Use this for initialization
	void Start () 
	{
		//speed = 4.0f;
		//health = 2;
		isAttacking = false;
		isDead = false;
		//attackTime = 1.5f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!isAttacking && !isDead)
			Move ();

	}

	void Move()
	{
		transform.position -= Vector3.right * Time.deltaTime * speed;
	}

	public float getAttackTime()
	{
		return attackTime;
	}	
	
	public void stopAttack()
	{
		isAttacking = false;
		myAnim.SetBool("isAttacking",false);
	}

	void getDamaged(int damage)
	{
		health -= damage;
		if (health <= 0)
			makeDead ();
	}

	void makeDead()
	{
		isDead = true;
		myAnim.SetBool("isDead",true);
		Destroy (gameObject, 2.0f);
	}

	void OnTriggerEnter2D(Collider2D otherColl)
	{
		if (otherColl.tag == "obstacle") 
		{
			isAttacking = true;
			myAnim.SetBool("isAttacking",true);
		}

		if (otherColl.tag == "bullet") 
		{
			if(!isDead)
			{
				if(otherColl.gameObject.GetComponent<BulletController>())
				{
					int damage = otherColl.gameObject.GetComponent<BulletController>().getDamage();
					Debug.Log ("current damage : " + damage);
					getDamaged(damage);
				}
			}
		}
	}

	void OnTriggerStay2D(Collider2D otherColl)
	{
		/*if (otherColl.tag == "obstacle") 
		{
			isAttacking = true;
			myAnim.SetBool("isAttacking",true);
		}*/
	}

	void OnTriggerExit2D(Collider2D otherColl)
	{
		if (otherColl.tag == "obstacle") 
		{
			isAttacking = false;
			myAnim.SetBool("isAttacking",false);
		}
	}


}
