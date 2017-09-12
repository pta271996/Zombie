using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public float speed;
    public Animator myAnim;
    public Rigidbody2D myRB;   
    public GameObject extraBodyParts;
    public GameObject weapon;
    public GameObject myGrenade;
    public GameObject ground;
    public Transform normalWeaponPos;
    public Transform attackWeaponPos;
    public Transform throwPos;
    

    private bool isRunning;
    private bool isAttacking;
    private bool isGettingHurted;
    private bool isThrowing;
    private bool isUsingPowerShot;
    private bool isDead;
    private float attackTime;
    private float attackDuration;
    private float attackAnimSpeed;
    private float throwTime;
    private float throwDuration;
    private GameObject myWeapon;
    private GameObject shadow;

    private bool isButtonShootPressed;

    private float powerAttackTime;
    private float powerAttackDuration;

    private float powerShootTime;
    private float powerShootDuration;

	// Use this for initialization
	void Start () 
    {
        isRunning = false;
        isAttacking = false;
        isGettingHurted = false;
        isThrowing = false;
        isUsingPowerShot = false;
        isDead = false;

        attackTime = 0.0f;
        throwTime = 0.0f;
        throwDuration = 0.8f;

        powerAttackTime = 0.0f;
        powerAttackDuration = 3.5f;
        powerShootTime = 0.0f;
        powerShootDuration = 0.2f;

        isButtonShootPressed = false;

        myWeapon = Instantiate(weapon, normalWeaponPos.position, Quaternion.identity) as GameObject;
        setNormalWeaponAttributes();
        attackDuration = myWeapon.GetComponent<GunController>().getShootDuration();
        attackAnimSpeed = myWeapon.GetComponent<GunController>().getShootAnimSpeed();

        shadow = GameObject.Find("player-shadow");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(!isDead)
        {
            if (Time.time >= attackTime && isAttacking && !isUsingPowerShot)
            {
                isAttacking = false;
                myAnim.SetBool("isAttacking", isAttacking);
                extraBodyParts.SetActive(false);
                myWeapon.GetComponent<GunController>().setNormalAnim();
                setNormalWeaponAttributes();
                myAnim.speed = 1.0f;
            }
            if (Time.time >= throwTime && isThrowing)
            {
                myWeapon.SetActive(true);
                isThrowing = false;
                myAnim.SetBool("isThrowing", isThrowing);
            }

            if (Input.GetKeyDown(KeyCode.L) && !isUsingPowerShot)
            {
                isUsingPowerShot = true;
                myAnim.SetBool("isJumping", true);
                powerAttackTime = Time.time + powerAttackDuration;
                powerShootTime = Time.time + 1.0f;
                Invoke("Jump", 0.175f);
            }

            if (isUsingPowerShot && Time.time >= powerAttackTime)
            {
                isUsingPowerShot = false;
                myWeapon.GetComponent<GunController>().setNormalAnim();
                setNormalWeaponAttributes();
                extraBodyParts.SetActive(false);
                myAnim.SetBool("isJumping", false);
                Fall();
            }

            if (isUsingPowerShot && Time.time >= powerShootTime)
            {
                ShootOnAir();
                powerShootTime = Time.time + powerShootDuration;
            }

            if (Input.GetKey(KeyCode.W) && !isAttacking && !isThrowing && !isUsingPowerShot)
            {
                isRunning = true;
                myAnim.SetBool("isRunning", isRunning);
                Move(0.0375f, 0.1f);
            }
            else if (Input.GetKey(KeyCode.S) && !isAttacking && !isThrowing && !isUsingPowerShot)
            {
                isRunning = true;
                myAnim.SetBool("isRunning", isRunning);
                Move(-0.0375f, -0.1f);
            }
            else if ((isButtonShootPressed || Input.GetKey(KeyCode.K)) && !isAttacking && !isThrowing)
            {
                isAttacking = true;
                isRunning = false;
                myAnim.SetBool("isAttacking", isAttacking);
                attackTime = Time.time + attackDuration;
                extraBodyParts.SetActive(true);
                setAttackWeaponAttributes();
                myAnim.speed = attackAnimSpeed;
                Shoot();
            }
            else if (Input.GetKeyDown(KeyCode.T) && !isThrowing && !isAttacking)
            {
                isThrowing = true;
                isRunning = false;
                myAnim.SetBool("isThrowing", isThrowing);
                throwTime = Time.time + throwDuration;
                myWeapon.SetActive(false);
                Invoke("Throw", 0.5f);
            }
            else
            {
                isRunning = false;
                myAnim.SetBool("isRunning", isRunning);
            }
        }      
	}

    void Move(float wInput, float hInput)
    {
        transform.position += Vector3.up * hInput * speed * Time.deltaTime;
        transform.position += Vector3.right * wInput * speed * Time.deltaTime;
    }

    void setNormalWeaponAttributes()
    {
        myWeapon.transform.position = normalWeaponPos.position;
        myWeapon.transform.parent = normalWeaponPos;
        myWeapon.GetComponent<GunController>().setNormalAngle();
        myWeapon.GetComponent<GunController>().setNormalLayerOrder();     
    }

    void setAttackWeaponAttributes()
    {
        myWeapon.transform.position = attackWeaponPos.position;
        myWeapon.transform.parent = attackWeaponPos;
        myWeapon.GetComponent<GunController>().setAttackAngle();
        myWeapon.GetComponent<GunController>().setAttackLayerOrder();
    }

    void Shoot()
    {
        myWeapon.GetComponent<GunController>().Shoot();
    }

    void PowerShoot()
    {
        myWeapon.GetComponent<GunController>().PowerShoot();
    }

    void Throw()
    {
        Instantiate(myGrenade, throwPos.position, Quaternion.identity);
        Instantiate(ground, new Vector2(transform.position.x + 8.97f, transform.position.y - 0.83f), Quaternion.identity);
    }

    void Jump()
    {
        myRB.AddForce(new Vector2(0.0f, 6.5f), ForceMode2D.Impulse);
        shadow.GetComponent<ShadowController>().setScaling(true);
        Invoke("stopForce", 0.65f);
    }

    void Fall()
    {
        myRB.AddForce(new Vector2(0.0f, -6.5f), ForceMode2D.Impulse);
        Invoke("stopForce", 0.65f);
    }

    void stopForce()
    {
        myRB.velocity = Vector2.zero;            
        if(!isUsingPowerShot)
            shadow.GetComponent<ShadowController>().setScaling(false);
    }

    void ShootOnAir()
    {
        setAttackWeaponAttributes();
        PowerShoot();
    }

    void makeDead()
    {
        myAnim.SetBool("isDead", true);
        Destroy(gameObject, 2.0f);
    }

    public void setMove(bool move)
    {
        isButtonShootPressed = move;    
    }

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if(otherColl.tag == "zombie")
        {
            speed = 0.0f;
            Invoke("makeDead", 0.4f);
        }
    }
   
}
