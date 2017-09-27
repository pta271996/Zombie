using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SZombieMom : MonoBehaviour {

    public float speed;
    public Animator myAnim;
    public GameObject mySon;
    public Transform giveBirthPos;
    public int health;
    public float giveBirthPosX;
    public float giveBirthDuration;
    public float delayTime;
    public int soundIndex;

    private float firstY;
    private float secondY;
    private Vector3 firstPos;
    private Vector3 secondPos;
    
    private bool isGivingBirth;
    private bool isTarget2ndY;

    private bool isSpawningChild;
    private float giveBirhtTime;
    

    private bool isDead;

	// Use this for initialization
	void Start () 
    {
        //giveBirthPosX = 5.5f;
        isGivingBirth = false;
        isTarget2ndY = true;
        giveBirhtTime = 0.0f;
        //giveBirthDuration = 0.4f;
        isSpawningChild = false;
        isDead = false;

        firstY = transform.position.y;
        if (transform.position.y < -2.5f)
            secondY = transform.position.y + 2.7f;
        else
            secondY = transform.position.y - 2.7f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (transform.position.x <= giveBirthPosX)
        {
            isGivingBirth = true;
            firstPos = new Vector3(transform.position.x,firstY,transform.position.z);
            secondPos = new Vector3(transform.position.x,secondY,transform.position.z);
        }

        if (!isGivingBirth)
            Move();
        else
        {
            if (!isDead)
            {
                if (Time.time >= giveBirhtTime && isSpawningChild)
                {
                    isSpawningChild = false;
                    myAnim.SetBool("isAttacking", false);
                }

                if (!isSpawningChild)
                {
                    if (isTarget2ndY)
                        transform.position = Vector3.MoveTowards(transform.position, secondPos, Time.deltaTime * speed);
                    else
                        transform.position = Vector3.MoveTowards(transform.position, firstPos, Time.deltaTime * speed);
                }

                if (isTarget2ndY && Vector3.Distance(transform.position, secondPos) <= 0.01f)
                {
                    isTarget2ndY = false;
                    myAnim.SetBool("isAttacking", true);
                    isSpawningChild = true;
                    giveBirhtTime = Time.time + giveBirthDuration;
                    GameObject soundManager = GameObject.Find("SoundManager");
                    soundManager.GetComponent<SoundsManager>().playZombieSound(soundIndex);
                    Invoke("GiveBirth", 0.25f);
                }
                if (!isTarget2ndY && Vector3.Distance(transform.position, firstPos) <= 0.01f)
                {
                    isTarget2ndY = true;
                    myAnim.SetBool("isAttacking", true);
                    isSpawningChild = true;
                    giveBirhtTime = Time.time + giveBirthDuration;
                    GameObject soundManager = GameObject.Find("SoundManager");
                    soundManager.GetComponent<SoundsManager>().playZombieSound(soundIndex);
                    Invoke("GiveBirth", delayTime);
                }
            }
        }
	}

    void Move()
    {      
        transform.position -= Vector3.right * Time.deltaTime * speed;      
    }

    void GiveBirth()
    {
        Instantiate(mySon, giveBirthPos.position, mySon.transform.rotation);
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
        myAnim.SetBool("isDead", true);

        GameObject heartPrefab = (GameObject)Resources.Load("Prefabs/big heart", typeof(GameObject));
        GameObject kidneyPrefab = (GameObject)Resources.Load("Prefabs/big kidney", typeof(GameObject));
        GameObject bonePrefab = (GameObject)Resources.Load("Prefabs/big bone", typeof(GameObject));
        GameObject brainPrefab = (GameObject)Resources.Load("Prefabs/big brain", typeof(GameObject));

        Instantiate(heartPrefab, transform.position, heartPrefab.transform.rotation);
        Instantiate(kidneyPrefab, transform.position, kidneyPrefab.transform.rotation);
        Instantiate(bonePrefab, transform.position, bonePrefab.transform.rotation);
        Instantiate(brainPrefab, new Vector3(transform.position.x, transform.position.y + 0.25f, 0.0f), brainPrefab.transform.rotation);

        Destroy(gameObject, 2.0f);
    }

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        
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
                getDamaged(5);
            }
        }

        if (otherColl.tag == "electricity")
        {
            if (!isDead)
            {
                getDamaged(10);
            }
        }

        if (otherColl.tag == "brain" || otherColl.tag == "saw")
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
}
