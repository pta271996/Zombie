using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SZombieFam : SZombie
{
    public GameObject skeleton;
    private float realSpeed;
    private int realHealth;

    void Awake()
    {
        isAttacking = false;
        isDead = false;
        isDeadByHeadShot = false;
        isDeadByBoom = false;
        isFrozen = false;
        realSpeed = speed;
        realHealth = health;
      
    }
    // Use this for initialization
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking && !isDead)
            Move();
        if(isAttacking && Time.time >= attackTime)
        {
            GameObject obstacle = GameObject.FindGameObjectWithTag("obstacle");
            if(obstacle)
            {
                obstacle.GetComponent<SObstacle>().getDamaged(damage);
                attackTime = Time.time + attackDuration;
            }
        }
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

        if(otherColl.tag == "electricity")
        {
            Instantiate(skeleton, transform.position, skeleton.transform.rotation);
            Destroy(gameObject);
        }

        if(otherColl.tag == "water")
        {
            if(!isFrozen)
            {
                isFrozen = true;
                transform.GetChild(1).gameObject.SetActive(true);
                GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 0);
                speed = 0.0f;
                realHealth = health;
                health = 1;
                myRB.AddForce(new Vector2(6.0f, 0.0f), ForceMode2D.Impulse);
                Invoke("stopForce", 0.35f);
                Invoke("BreakIce", breakIceTime);
            }           
        }

        if(otherColl.tag == "brain")
        {
            setDead();
            makeDead();
        }
    }

    void BreakIce()
    {
        isFrozen = false;
        transform.GetChild(1).gameObject.SetActive(false);
        GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 1);      
        health = realHealth;
        GameObject icePrefab = (GameObject)Resources.Load("Prefabs/Effects/IceBreaking PS", typeof(GameObject));
        Instantiate(icePrefab, transform.position, icePrefab.transform.rotation);
        Invoke("ResetSpeed", 0.2f);
    }

    void ResetSpeed()
    {
        speed = realSpeed;
    }

    void OnTriggerStay2D(Collider2D otherColl)
    {
        /*if (otherColl.tag == "obstacle") 
        {
            isAttacking = true;
            myAnim.SetBool("isAttacking",true);
        }*/
    }

    void OnTriggerExit2D(Collider2D otherColl)
    {
        if (otherColl.tag == "obstacle")
        {
            isAttacking = false;
            myAnim.SetBool("isAttacking", false);
        }
    }
    public override void SetUp(int level, int line)
    {

        base.SetUp(level, line);
        //ta se set up health, dameattack, attackspeed ,... cua zombie trong ham nay tuy theo level
        //Debug.Log("Create ZombieA success");
    }

}
