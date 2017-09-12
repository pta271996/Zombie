using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SZombie : MonoBehaviour {

	[SerializeField]
	protected float speed;// = 4.0f;
	[SerializeField]
	protected int health;// = 2;
	[SerializeField]
	protected float attackTime;// = 1.5f;
    [SerializeField]
    protected float attackDuration;
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected float breakIceTime;
	[SerializeField]
	protected Animator myAnim;
	[SerializeField]
	protected Rigidbody2D myRB;

	protected int levelPower;   //level Power la cac muc suc manh cua zombie se duoc dieu chinh tuy vao man choi
	// thong thuong se tang levelPower khi man choi cang kho hon
	// bien nay se duoc chinh trong ham SetUp();

	protected bool isAttacking;
	protected bool isDead;
    protected bool isDeadByNormalShot;
    protected bool isDeadByHeadShot;
    protected bool isDeadByBoom;
    protected bool isFrozen;
    protected bool isChasingEnemy;

    private GameObject heart;
    private GameObject kidney;
    private GameObject bone;

    
	protected int line;

	public void Move()
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

    public void setDead()
    {
        isDeadByNormalShot = true;
        isDeadByHeadShot = false;
        isDeadByBoom = false;
    }

    public void setDeadByHeadShot()
    {
        isDeadByHeadShot = true;
        isDeadByNormalShot = false;
        isDeadByBoom = false;
    }

    public void setDeadByBoom()
    {
        isDeadByBoom = true;
        isDeadByNormalShot = false;
        isDeadByHeadShot = false;
    }

	public void getDamaged(int damage)
	{
		health -= damage;
		myRB.AddForce(new Vector2(2.5f, 0.0f), ForceMode2D.Impulse);
		Invoke("stopForce", 0.35f);
		if (health <= 0)
			makeDead ();
	}

	public void stopForce()
	{
		myRB.velocity = Vector2.zero;
	}

	public void makeDead()
	{
		isDead = true;
		Destroy(gameObject.GetComponent<CircleCollider2D>());
		Destroy(gameObject.GetComponent<BoxCollider2D>());
		stopForce();

        if (GetComponent<SZombieFam>())
        {
            GameObject shadow = transform.Find("shadow").gameObject;
            Destroy(shadow);
        }

        if(isFrozen)
        {
            transform.GetChild(1).gameObject.SetActive(false);
            GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 1);
        }

        if (isDeadByNormalShot)
        {
            myAnim.SetBool("isDead", true);
            if(GetComponent<SZombieFam>())
            {
                GameObject heartPrefab = (GameObject)Resources.Load("Prefabs/heart", typeof(GameObject));
                GameObject kidneyPrefab = (GameObject)Resources.Load("Prefabs/kidney", typeof(GameObject));
                GameObject bonePrefab = (GameObject)Resources.Load("Prefabs/bone", typeof(GameObject));
                Instantiate(heartPrefab, transform.position, heartPrefab.transform.rotation);
                Instantiate(kidneyPrefab, transform.position, kidneyPrefab.transform.rotation);

                float ran = Random.Range(0.0f, 1.0f);
                if (ran >= 0.5f)
                {
                    Instantiate(bonePrefab, transform.position, bonePrefab.transform.rotation);
                    Instantiate(bonePrefab, transform.position, bonePrefab.transform.rotation);
                }
                else
                {
                    Instantiate(bonePrefab, transform.position, bonePrefab.transform.rotation);
                }
            }
            else if(GetComponent<SZombieJump>())
            {
                GameObject heartPrefab = (GameObject)Resources.Load("Prefabs/big heart", typeof(GameObject));
                GameObject kidneyPrefab = (GameObject)Resources.Load("Prefabs/big kidney", typeof(GameObject));
                GameObject bonePrefab = (GameObject)Resources.Load("Prefabs/big bone", typeof(GameObject));
                Instantiate(heartPrefab, transform.position, heartPrefab.transform.rotation);
                Instantiate(kidneyPrefab, transform.position, kidneyPrefab.transform.rotation);

                float ran = Random.Range(0.0f, 1.0f);
                if (ran >= 0.5f)
                {
                    Instantiate(bonePrefab, transform.position, bonePrefab.transform.rotation);
                    Instantiate(bonePrefab, transform.position, bonePrefab.transform.rotation);
                }
                else
                {
                    Instantiate(bonePrefab, transform.position, bonePrefab.transform.rotation);
                }
            }
            

        }
        else if (isDeadByHeadShot)
        {
            myAnim.SetBool("isDeadByHeadShot", true);
            if (gameObject.GetComponent<MoveUp>())
                gameObject.GetComponent<MoveUp>().Move();      
    
            if(GetComponent<SZombieFam>())
            {
                GameObject brainPrefab = (GameObject)Resources.Load("Prefabs/brain", typeof(GameObject));
                Instantiate(brainPrefab, new Vector3(transform.position.x, transform.position.y + 0.25f, 0.0f), brainPrefab.transform.rotation);        
            }
            else if (GetComponent<SZombieJump>())
            {
                GameObject brainPrefab = (GameObject)Resources.Load("Prefabs/big brain", typeof(GameObject));
                Instantiate(brainPrefab, new Vector3(transform.position.x, transform.position.y + 0.25f, 0.0f), brainPrefab.transform.rotation);        
            }
            
        }
        else if (isDeadByBoom)
            myAnim.SetBool("isDeadByBoom", true);
      
		Destroy (gameObject, 2.0f);
	}
	public float Speech{
		get{
			return this.speed;
		}
		set{
			this.speed = value;
		}
	}
	public int Health {
		get{
			return this.health;
		}
		set{
			this.health = value;
		}
	}
	public float AttackTime {
		get{
			return this.attackTime;
		}
		set{
			this.attackTime = value;
		}
	}

	public int LevelPower {
		get{
			return this.levelPower;
		}
		set{
			this.levelPower = value;
		}

	}
	public int Line {
		get{
			return this.line ;
		}
		set{
			this.line = value;
		}

	}

	//ham setup se tinh toan suc manh cua zombie dua theo level cua no
	//ham SetUp duoc tham chieu trong ham summon() cua lop ZombieManager khi khoi tao man choi va sinh ra zombie
	public virtual void SetUp(int level, int line){
		this.levelPower = level;
		this.line = line;
		//ta se set up health, dameattack, attackspeed ,... cua zombie trong ham nay tuy theo level

	}
}
