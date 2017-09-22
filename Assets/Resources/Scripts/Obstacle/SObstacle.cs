using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SObstacle : MonoBehaviour {

	protected int state;
	protected bool isDead;
	protected bool isBeingAttacked;  
    protected int currentHealth;

    public int health;
    public string strSpriteName;
    public Animator myAnim;
    public GameObject shadow;

    public Image healthBar;

	protected int level;
	protected int line;

    private int zombieCollisionCount = 0;
	// Use this for initialization
	

    void Start()
    {
        currentHealth = health;
        state = 1;
        loadStateSprite();
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

        healthBar.fillAmount = (float)currentHealth / (float)health;

        if (healthBar.fillAmount > 0.575f)
            healthBar.color = new Color(0.06f, 0.96f, 0.063f, 1.0f);
        if (healthBar.fillAmount > 0.3f && healthBar.fillAmount <= 0.575f)
            healthBar.color = new Color(1.0f, 0.92f, 0.0f, 1.0f);
        if (healthBar.fillAmount >= 0.0f && healthBar.fillAmount <= 0.3f)
            healthBar.color = new Color(0.96f, 0.06f, 0.86f, 1.0f);

        if(currentHealth <= 0)
        {
            Destroy(shadow);
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
