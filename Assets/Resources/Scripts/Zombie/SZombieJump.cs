using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SZombieJump : SZombie
{
    public GameObject skeleton;
    public float jumpTime;
    public float jumpDuration;

    private bool isJumping;

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
        Invoke("PrepareJump", jumpTime);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!isAttacking && !isDead)
            Move();
        if (isAttacking && Time.time >= attackTime)
        {
            GameObject obstacle = GameObject.FindGameObjectWithTag("obstacle");
            if (obstacle)
            {
                obstacle.GetComponent<SObstacle>().getDamaged(damage);
                attackTime = Time.time + attackDuration;
            }
        }

        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);
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
    }

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if (otherColl.tag == "obstacle")
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
    }
}
