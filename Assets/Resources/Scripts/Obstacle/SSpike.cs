using UnityEngine;
using System.Collections;

public class SSpike : SObstacle 
{
    public GameObject woodDustPS;

	void Awake(){
		state = 1;
		isBeingAttacked = false;
		isDead = false;

	}
	// Use this for initialization
	void Start () 
	{
		loadStateSprite ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (isBeingAttacked) 
		{
            woodDustPS.SetActive(true);

			if(Time.time >= startTimeBeingAttacked)
			{
				getDamaged();
				startTimeBeingAttacked = Time.time + enemyAttackTime;
			}
		}
	}


	void OnTriggerEnter2D(Collider2D otherColl)
	{
		if (otherColl.tag == "zombie") 
		{
            if(!isBeingAttacked)
            {
                isBeingAttacked = true;
                if (otherColl.gameObject.GetComponent<SZombie>())
                {
                    enemyAttackTime = otherColl.gameObject.GetComponent<SZombie>().getAttackTime();
                    startTimeBeingAttacked = Time.time + enemyAttackTime;
                }
            }		
		}
	}

	void OnTriggerStay2D(Collider2D otherColl)
	{
		if (otherColl.tag == "zombie") 
		{
			isBeingAttacked = true;
			if(isDead)
			{
				if(otherColl.gameObject.GetComponent<SZombie>())
				{
					otherColl.gameObject.GetComponent<SZombie>().stopAttack();
				}
				Destroy(gameObject);
			}
		}
	}

	void OnTriggerExit2D(Collider2D otherColl)
	{
		if (otherColl.tag == "zombie") 
		{
			isBeingAttacked = false;
		}
	}
}
