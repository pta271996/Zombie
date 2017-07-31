using UnityEngine;
using System.Collections;

public class SZombieA :SZombie {
	
	void Awake(){
		isAttacking = false;
		isDead = false;
		//speed = 4.0f;
		//health = 2;
		//attackTime = 1.5f;
	}
	// Use this for initialization
	void Start () 
	{
		//speed = 4.0f;
		//health = 2;
	
		//attackTime = 1.5f;
	}

	// Update is called once per frame
	void Update () 
	{
		if(!isAttacking && !isDead)
			Move ();
	}


	void OnTriggerEnter2D(Collider2D otherColl)
	{
		if (otherColl.tag == "obstacle") 
		{
			if (otherColl.gameObject.GetComponent<SObstacle> ().Line == this.line) {
				
				isAttacking = true;
				myAnim.SetBool ("isAttacking", true);
			}
		}

		if (otherColl.tag == "bullet") 
		{
			if(!isDead)
			{
				if(otherColl.gameObject.GetComponent<SBullet>())
				{
					int damage = otherColl.gameObject.GetComponent<SBullet>().getDamage();
					//Debug.Log ("current damage : " + damage);
					getDamaged(damage);
				}
				if (otherColl.gameObject.GetComponent<SRay>())
                {
					int damage = otherColl.gameObject.GetComponent<SRay>().getDamage();
                   // Debug.Log("current damage : " + damage);
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
	public override void SetUp(int level, int line){
		
		base.SetUp (level, line);
		//ta se set up health, dameattack, attackspeed ,... cua zombie trong ham nay tuy theo level
		//Debug.Log("Create ZombieA success");
	}

}
