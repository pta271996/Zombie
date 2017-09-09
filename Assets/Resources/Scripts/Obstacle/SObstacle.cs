using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SObstacle : MonoBehaviour {

	protected int state;
	protected bool isDead;
	protected bool isBeingAttacked;  
    protected int currentHealth;

    public int health;
    public string strSpriteName;
    public Animator myAnim;

	protected int level;
	protected int line;

    private int zombieCollisionCount = 0;
	// Use this for initialization
	

    void Start()
    {
        currentHealth = health;
        isBeingAttacked = false;
        isDead = false;
    }

    void Update()
    {
        if(isNotCollidingZombie())
        {
            isBeingAttacked = false;
            myAnim.SetBool("isBeingAttacked", false);
        }
    }

	public void loadStateSprite()
	{
        string strState = strSpriteName + state.ToString();
		gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Graphic/Obstacles/" + strState);
	}


    public void getDamaged(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        if(currentHealth <= (int)(health/2) && currentHealth > (int)(health / 4))
        {
            state = 2;
            loadStateSprite();
        }

        if (currentHealth <= (int)(health / 4) && currentHealth > 0)
        {
            state = 3;
            loadStateSprite();
        }
    }
	
    void startBeingAttackedAnim()
    {
        isBeingAttacked = true;
        myAnim.SetBool("isBeingAttacked", true);
    }

    public bool isNotCollidingZombie()
    {
        return zombieCollisionCount == 0;
    }

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if(otherColl.tag == "zombie")
        {
            zombieCollisionCount++;
            if(!isBeingAttacked)
                Invoke("startBeingAttackedAnim", 0.5f);
        }
    }

    void OnTriggerExit2D(Collider2D otherColl)
    {
        if (otherColl.tag == "zombie")
        {
            zombieCollisionCount--;           
        }
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
