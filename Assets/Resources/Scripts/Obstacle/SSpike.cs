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
        else
        {
            woodDustPS.SetActive(false);
        }
	}


	void OnTriggerEnter2D(Collider2D otherColl)
	{
		if (otherColl.tag == "zombie") 
		{
			if (otherColl.gameObject.GetComponent<SZombie> ().Line == this.line) {
				if (!isBeingAttacked) {
					isBeingAttacked = true;
					if (otherColl.gameObject.GetComponent<SZombie> ()) {
						enemyAttackTime = otherColl.gameObject.GetComponent<SZombie> ().getAttackTime ();
						startTimeBeingAttacked = Time.time + enemyAttackTime;
					}
				}	
			}
		}
	}

	void OnTriggerStay2D(Collider2D otherColl)
	{
		if (otherColl.tag == "zombie") 
		{
			if (otherColl.gameObject.GetComponent<SZombie> ().Line == this.line) {
				if (!isBeingAttacked)
					isBeingAttacked = true;
				if (isDead) {
					if (otherColl.gameObject.GetComponent<SZombie> ()) {
						otherColl.gameObject.GetComponent<SZombie> ().stopAttack ();
					}
					Destroy (gameObject);
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D otherColl)
	{
		if (otherColl.tag == "zombie") 
		{
			if (otherColl.gameObject.GetComponent<SZombie> ().Line == this.line) {
				// Debug.Log("Exit");
				isBeingAttacked = false;
			}
		}
	}

	public override void SetUp(int level, int line){

		base.SetUp (level, line);
		//ta se set up health, dameattack, attackspeed ,... cua zombie trong ham nay tuy theo level
		//Debug.Log("Create Spike success");
	}

}
