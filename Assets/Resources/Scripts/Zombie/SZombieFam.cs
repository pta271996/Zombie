using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SZombieFam : SZombie
{
    public GameObject skeleton;
    public int soundIndex;
    public float moanTime;

    private bool isPlayingSound;
    private bool isShocked;
    private float realSpeed;
    private int realHealth;
    private GameObject enemy;
    private GameObject obstacle;
    

    void Awake()
    {
        isAttacking = false;
        isDead = false;
        isDeadByHeadShot = false;
        isDeadByBoom = false;
        isFrozen = false;
        isChasingEnemy = false;
        isPlayingSound = false;
        isShocked = false;

        realSpeed = speed;
        realHealth = health;
      
    }
    // Use this for initialization
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Player");
        obstacle = GameObject.FindGameObjectWithTag("obstacle");
        moanTime = Time.time + moanTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= moanTime && !isPlayingSound)
        {
            isPlayingSound = true;
            GameObject soundManager = GameObject.Find("SoundManager");
            soundManager.GetComponent<SoundsManager>().playZombieSound(soundIndex);
        }

        if (!isAttacking && !isDead && !isChasingEnemy)
            Move();
        if(isAttacking)
        {
            if(obstacle)
            {
                if(Time.time >= attackTime )
                {
                    obstacle.GetComponent<SObstacle>().getDamaged(damage);
                    attackTime = Time.time + attackDuration;
                    GameObject soundManager = GameObject.Find("SoundManager");
                    soundManager.GetComponent<SoundsManager>().playZombieSound(soundIndex);
                }               
            }             
        }

        if(!obstacle)
        {
            isChasingEnemy = true;
        }

        if(isChasingEnemy && !isDead)
        {
            if (enemy)
            {
                if(enemy.GetComponent<PlayerController>().getFlying())
                    transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, Time.deltaTime * 0.0f);
                else
                    transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, Time.deltaTime * speed);
            }
        }

        if (isDeadByBoom)
            GetComponent<SpriteRenderer>().material.color = Color.Lerp(GetComponent<SpriteRenderer>().material.color, new Color(1.0f, 0.0f, 0.0f, 1.0f), 1.5f * Time.deltaTime);
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

        if(otherColl.tag == "electricity" && !isShocked)
        {
            isShocked = true;
            Instantiate(skeleton, transform.position, skeleton.transform.rotation);
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<GameManager>().increaseDeadZombieNum(); 
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

        if (otherColl.tag == "saw")
        {
            GameObject soundManager = GameObject.Find("SoundManager");
            soundManager.GetComponent<SoundsManager>().playSawHitSound();
            setDeadByHeadShot();
            makeDead();
        }

        if(otherColl.tag == "projectile")
        {
            if (!isDead)
            {
                int damage = otherColl.gameObject.GetComponent<ProjectileController>().getDamage();
                setDead();
                getDamaged(damage);             
            }
        }
    }

    void BreakIce()
    {
        if (!isDead)
        {
            isFrozen = false;
            if (transform.childCount > 1)
                transform.GetChild(1).gameObject.SetActive(false);
            GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 1);
            health = realHealth;
            GameObject icePrefab = (GameObject)Resources.Load("Prefabs/Effects/IceBreaking PS", typeof(GameObject));
            Instantiate(icePrefab, transform.position, icePrefab.transform.rotation);
            Invoke("ResetSpeed", 0.2f);
        }
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

        if(otherColl.tag == "Player")
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
