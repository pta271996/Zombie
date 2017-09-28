using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
    public float speed;
    public Animator myAnim;
    public Rigidbody2D myRB;   
    public GameObject extraBodyParts;
    public GameObject weapon;
    public GameObject myProjectile;
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
    private bool isFlying;
    private float attackTime;
    private float attackDuration;
    private float attackAnimSpeed;
    private float throwTime;
    private float throwDuration;
    private GameObject myWeapon;
    private GameObject shadow;
    public GameObject weaponsManager;
    public GameObject powerManager;
    public GameObject powerPS;

    private bool isButtonShootPressed;
    private bool isButtonMoveUpPressed;
    private bool isButtonMoveDownPressed;
    private bool isButtonThrowPressed;

    private float powerAttackTime;
    private float powerAttackDuration;

    private float powerShootTime;
    private float powerShootDuration;

    private string currentWeapon;

    public Image imgShoot;
    public Image imgMoveUp;
    public Image imgMoveDown;
    public Image imgSwitchWP;
    public Image imgThrow;

    public GameObject soundManager;

	// Use this for initialization
	void Start () 
    {       
        isRunning = false;
        isAttacking = false;
        isGettingHurted = false;
        isThrowing = false;
        isUsingPowerShot = false;
        isDead = false;
        isFlying = false;

        attackTime = 0.0f;
        throwTime = 0.0f;
        throwDuration = 0.8f;

        powerAttackTime = 0.0f;
        powerAttackDuration = 3.5f;
        powerShootTime = 0.0f;
        powerShootDuration = 0.2f;

        isButtonShootPressed = false;
        isButtonMoveUpPressed = false;
        isButtonMoveDownPressed = false;
        isButtonThrowPressed = false;

        //weaponsManager = GameObject.FindGameObjectWithTag("WeaponsManager");
        //if (weaponsManager)

        //PrepareWeapon();
        Invoke("PrepareWeapon", 0.1f);
        shadow = GameObject.Find("player-shadow");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(!isDead)
        {
            if (powerManager.GetComponent<PowerController>().isFull())
                powerPS.SetActive(true);
            else
                powerPS.SetActive(false);


            if (transform.position.y > -0.85f && !isFlying)
                transform.position = new Vector3(transform.position.x, -0.85f, transform.position.z);
            if (transform.position.y < -4.05f && !isFlying)
                transform.position = new Vector3(transform.position.x, -4.0f, transform.position.z);

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

            if (Input.GetKeyDown(KeyCode.L) && !isUsingPowerShot && powerManager.GetComponent<PowerController>().isFull())
            {
                isUsingPowerShot = true;
                isFlying = true;
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

            if ((Input.GetKey(KeyCode.W) || isButtonMoveUpPressed) && !isAttacking && !isThrowing && !isUsingPowerShot)
            {
                isRunning = true;
                myAnim.SetBool("isRunning", isRunning);
                Move(0.0375f, 0.1f);
            }
            else if ((Input.GetKey(KeyCode.S) || isButtonMoveDownPressed) && !isAttacking && !isThrowing && !isUsingPowerShot)
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
            else if (( isButtonThrowPressed ||Input.GetKey(KeyCode.T)) && !isThrowing && !isAttacking)
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
        if (transform.position.y <= -0.85f && transform.position.y >= -4.0f)    
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
        weaponsManager.GetComponent<WeaponsController>().setTextBulletNum(myWeapon.GetComponent<GunController>().getBulletNum());
        soundManager.GetComponent<SoundsManager>().playGunSound(myWeapon.name);
    }

    void PowerShoot()
    {  
        powerManager.GetComponent<PowerController>().resetPowerNum();
        myWeapon.GetComponent<GunController>().PowerShoot();
        soundManager.GetComponent<SoundsManager>().playGunSound(myWeapon.name);
    }

    void Throw()
    {
        Instantiate(myProjectile, throwPos.position, myProjectile.transform.rotation);
        soundManager.GetComponent<SoundsManager>().playThrowSound();
        //Instantiate(ground, new Vector2(transform.position.x + 8.97f, transform.position.y - 0.83f), Quaternion.identity);
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
        if (myRB.velocity.y <= 0)
            isFlying = false;
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

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if (otherColl.tag == "zombie")
        {
            speed = 0.0f;
            Invoke("makeDead", 0.4f);
        }
    }

    void PrepareWeapon()
    {       
         currentWeapon = weaponsManager.GetComponent<WeaponsController>().getCurrentWeaponString();
         weapon = (GameObject)Resources.Load("Prefabs/Weapons/" + currentWeapon, typeof(GameObject));
         //Debug.Log(weaponsManager.GetComponent<WeaponsController>().getCurrentWeaponString());

        GameObject weaponPos = transform.Find(currentWeapon + " pos").gameObject;
        if (weaponPos)
        {
            normalWeaponPos = weaponPos.transform.GetChild(0);
            attackWeaponPos = weaponPos.transform.GetChild(1);
        }

        myWeapon = Instantiate(weapon, normalWeaponPos.position, Quaternion.identity) as GameObject;
        setNormalWeaponAttributes();
        attackDuration = myWeapon.GetComponent<GunController>().getShootDuration();
        attackAnimSpeed = myWeapon.GetComponent<GunController>().getShootAnimSpeed();
    }

    void SwitchWeapon()
    {
        if (!isAttacking && !isUsingPowerShot)
        {
            if (weaponsManager)
            {
                weaponsManager.GetComponent<WeaponsController>().switchWeapon();
                currentWeapon = weaponsManager.GetComponent<WeaponsController>().getCurrentWeaponString();
                weapon = (GameObject)Resources.Load("Prefabs/Weapons/" + currentWeapon, typeof(GameObject));
            }

            GameObject weaponPos = transform.Find(currentWeapon + " pos").gameObject;
            if (weaponPos)
            {
                normalWeaponPos = weaponPos.transform.GetChild(0);
                attackWeaponPos = weaponPos.transform.GetChild(1);
            }

            Destroy(myWeapon);
            myWeapon = Instantiate(weapon, normalWeaponPos.position, Quaternion.identity) as GameObject;
            setNormalWeaponAttributes();
            attackDuration = myWeapon.GetComponent<GunController>().getShootDuration();
            attackAnimSpeed = myWeapon.GetComponent<GunController>().getShootAnimSpeed();
        }
    }

    public void setShoot(bool shoot)
    {
        isButtonShootPressed = shoot;  
        
        if(shoot)
        {
            imgShoot.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else
        {
            imgShoot.color = new Color(1.0f, 1.0f, 1.0f, 0.55f);
        }
    }

    public void setMoveUp(bool move)
    {
        isButtonMoveUpPressed = move;

        if (move)
        {
            imgMoveUp.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else
        {
            imgMoveUp.color = new Color(1.0f, 1.0f, 1.0f, 0.55f);
        }
    }

    public void setMoveDown(bool move)
    {
        isButtonMoveDownPressed = move;

        if (move)
        {
            imgMoveDown.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else
        {
            imgMoveDown.color = new Color(1.0f, 1.0f, 1.0f, 0.55f);
        }
    }

    public void ChangeWeapon(bool change)
    {
        if (change)
        {
            SwitchWeapon();
            imgSwitchWP.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else
        {
            imgSwitchWP.color = new Color(1.0f, 1.0f, 1.0f, 0.55f);
        }
    }

    public void setThrow(bool Throw)
    {
        isButtonThrowPressed = Throw;

        if (Throw)
        {
            imgThrow.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else
        {
            imgThrow.color = new Color(1.0f, 1.0f, 1.0f, 0.55f);
        }
    }

    public bool getFlying()
    {
        return isFlying;
    }
}
