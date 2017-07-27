using UnityEngine;
using System.Collections;

public class SpikeController : MonoBehaviour {

	private int state;
	private bool isDead;
	private bool isBeingAttacked;
	private float startTimeBeingAttacked;
	private float enemyAttackTime;


	// Use this for initialization
	void Start () 
	{
		state = 1;
		isBeingAttacked = false;
		isDead = false;
		loadStateSprite ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isBeingAttacked) 
		{
			if(Time.time >= startTimeBeingAttacked)
			{
				getDamaged();
				startTimeBeingAttacked = Time.time + enemyAttackTime;
			}
		}
	}

	void getDamaged()
	{
		if (state >= 3) 
		{
			makeDead ();
		} 
		else
		{
			state++;
			loadStateSprite ();
		}
	}

	void loadStateSprite()
	{
		string strState = "wooden_spike_state" + state.ToString () ;
		gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Graphic/Obstacles/" + strState);
	}

	void makeDead()
	{
		isDead = true;
		//Destroy (gameObject);
	}

	void NotifyDeath()
	{

	}

	void OnTriggerEnter2D(Collider2D otherColl)
	{
		if (otherColl.tag == "zombie") 
		{
			isBeingAttacked = true;
			if(otherColl.gameObject.GetComponent<ZombieController>())
			{
				enemyAttackTime = otherColl.gameObject.GetComponent<ZombieController>().getAttackTime();
				startTimeBeingAttacked = Time.time + enemyAttackTime;
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
				if(otherColl.gameObject.GetComponent<ZombieController>())
				{
					otherColl.gameObject.GetComponent<ZombieController>().stopAttack();
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
