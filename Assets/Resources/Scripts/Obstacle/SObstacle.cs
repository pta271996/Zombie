using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SObstacle : MonoBehaviour {

	protected int state;
	protected bool isDead;
	protected bool isBeingAttacked;
	protected float startTimeBeingAttacked;
	protected float enemyAttackTime;

    public string strSpriteName;

	protected int level;
	protected int line;
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
        string strState = strSpriteName + state.ToString();
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

	public virtual void SetUp(int level, int line){
		this.level = level;
		this.line = line;
		//ta se set up health, dameattack, attackspeed ,... cua zombie trong ham nay tuy theo level

	}
	public int Line {
		get{
			return this.line ;
		}
		set{
			this.line = value;
		}

	}
}
