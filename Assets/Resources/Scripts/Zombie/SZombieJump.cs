using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SZombieJump : SZombie
{
    public GameObject skeleton;
    public float jumpTime;
    public float jumpDuration;

    private bool isJumping;
    private GameObject enemy;
    private GameObject obstacle;

    void Awake()
    {
        isAttacking = false;
        isDead = false;
        isDeadByHeadShot = false;
        isDeadByBoom = false;      
    }

	// Use this for initialization
	void Start () 
    {
        //jumpTime = Time.time + jumpTime;
        isJumping = false;
        transform.DetachChildren();
        enemy = GameObject.FindGameObjectWithTag("Player");
        obstacle = GameObject.FindGameObjectWithTag("obstacle");
        Invoke("PrepareJump", jumpTime);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!isAttacking && !isDead)
            Move();
        if (isAttacking && Time.time >= attackTime)
        {
            if (obstacle)
            {
                obstacle.GetComponent<SObstacle>().getDamaged(damage);
                attackTime = Time.time + attackDuration;
            }
        }

        if (!obstacle)
        {
            isChasingEnemy = true;
        }

        if (isChasingEnemy)
        {
            if (enemy)
            {
                if (enemy.GetComponent<PlayerController>().getFlying())
                    transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, Time.deltaTime * 0.0f);
                else
                    transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, Time.deltaTime * speed);
            }
        }

        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

        if(isDeadByBoom)
            GetComponent<SpriteRenderer>().material.color = Color.Lerp(GetComponent<SpriteRenderer>().material.color, new Color(1.0f, 0.0f, 0.0f, 1.0f), 1.5f * Time.deltaTime);
	}

    void PrepareJump()
    {
        isJumping = true;
        myAnim.SetBool("isJumping", true);
        if (GetComponent<CircleCollider2D>())
            GetComponent<CircleCollider2D>().enabled = false;
        if (GetComponent<BoxCollider2D>())
            GetComponent<BoxCollider2D>().enabled = false;
        Invoke("Jump", 0.2f);
    }

    void Jump()
    {
        myRB.gravityScale = 1.0f;
        myRB.AddForce(new Vector2(0.0f, 10.0f), ForceMode2D.Impulse);   
        speed = 4.5f;       
        Invoke("Land", jumpDuration);
    }

    void Land()
    {
        myRB.gravityScale = 0.0f;
        myRB.velocity = Vector2.zero;
        isJumping = false;
        myAnim.SetBool("isJumping", false);
        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        GameObject dust = (GameObject)Resources.Load("Prefabs/Effects/dust burstPS", typeof(GameObject));
        Instantiate(dust, new Vector3(transform.position.x-0.2f, transform.position.y - 0.9f, 0.0f), dust.transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if (otherColl.tag == "obstacle" || otherColl.tag == "Player")
        {
            //if (otherColl.gameObject.GetComponent<SObstacle>().Line == this.line)
            {
                isAttacking = true;
                myAnim.SetBool("isAttacking", true);
            }
        }

        if (otherColl.tag == "bullet")
        {
            if (!isDead)
            {
                if (otherColl.gameObject.GetComponent<SBullet>())
                {
                    int damage = otherColl.gameObject.GetComponent<SBullet>().getDamage();
                    getDamaged(damage);
                }
                if (otherColl.gameObject.GetComponent<SRay>())
                {
                    int damage = otherColl.gameObject.GetComponent<SRay>().getDamage();
                    getDamaged(damage);
                }
            }
        }

        if (otherColl.tag == "grenade")
        {
            if (!isDead)
            {
                getDamaged(10);
            }
        }

        if (otherColl.tag == "electricity")
        {
            Instantiate(skeleton, transform.position, skeleton.transform.rotation);
            Destroy(gameObject);
        }

        if (otherColl.tag == "brain")
        {
            setDead();
            makeDead();
        }
    }

    void OnTriggerExit2D(Collider2D otherColl)
    {
        if (otherColl.tag == "obstacle")
        {
            isAttacking = false;
            myAnim.SetBool("isAttacking", false);
        }

        if (otherColl.tag == "Player")
        {
            isAttacking = false;
            myAnim.SetBool("isAttacking", false);
        }
    }
}
