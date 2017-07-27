using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SObstacle : MonoBehaviour {

	protected int state;
	protected bool isDead;
	protected bool isBeingAttacked;
	protected float startTimeBeingAttacked;
	protected float enemyAttackTime;
	// Use this for initialization
	public void getDamaged()
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

	public void loadStateSprite()
	{
		string strState = "wooden_spike_state" + state.ToString () ;
		gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Graphic/Obstacles/" + strState);
	}

	public void makeDead()
	{
		isDead = true;
		//Destroy (gameObject);
	}

	public void NotifyDeath()
	{

	}

}
