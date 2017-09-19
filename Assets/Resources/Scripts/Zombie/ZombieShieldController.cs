using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieShieldController : MonoBehaviour {

    public GameObject zombie;
    public GameObject brokenShield;
    public Transform shieldPos;
    public float speed;
    public int health;
    public int damage;
    public float attackTime;
    public float attackDuration;
    public Animator myAnim;

    private bool isAttacking;
    private bool isDead;
    private bool isChasingEnemy;

    private GameObject enemy;
    private GameObject obstacle;

	// Use this for initialization
	void Start () 
    {
        isAttacking = false;
        isDead = false;
        isChasingEnemy = false;

        enemy = GameObject.FindGameObjectWithTag("Player");
        obstacle = GameObject.FindGameObjectWithTag("obstacle");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!isAttacking && !isDead && !isChasingEnemy)
            Move();

        if (isAttacking)
        {
            if (obstacle)
            {
                if (Time.time >= attackTime)
                {
                    obstacle.GetComponent<SObstacle>().getDamaged(damage);
                    attackTime = Time.time + attackDuration;
                }
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
                transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, Time.deltaTime * speed);
            }
        }
	}

    void Move()
    {
        transform.position -= Vector3.right * Time.deltaTime * speed;
    }

    void getDamaged(int damage)
    {
        health -= damage;       
        if (health <= 0)
            makeDead();
    }

    void makeDead()
    {
        isDead = true;        
        Instantiate(zombie,transform.position,zombie.transform.rotation);
        Instantiate(brokenShield, shieldPos.position, brokenShield.transform.rotation);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D otherColl)
    {

        if (otherColl.tag == "obstacle" || otherColl.tag == "Player")
        {
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
                isDead = true;
                myAnim.SetBool("isDeadByBoom",true);
                Destroy(gameObject,2.0f);
            }
        }

        if (otherColl.tag == "electricity" || otherColl.tag == "laser")
        {
            if (!isDead)
            {
                getDamaged(10);
            }
        }

        if (otherColl.tag == "brain")
        {
            makeDead();
        }

        if (otherColl.tag == "battery")
        {
            if (!isDead)
            {
                getDamaged(5);
            }
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
