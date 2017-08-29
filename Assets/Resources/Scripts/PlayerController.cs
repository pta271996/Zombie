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
    private float attackTime;
    private float attackDuration;
    private float throwTime;
    private float throwDuration;
    private GameObject myWeapon;
    


	// Use this for initialization
	void Start () 
    {
        isRunning = false;
        isAttacking = false;
        isGettingHurted = false;
        isThrowing = false;

        attackTime = 0.0f;
        attackDuration = 0.8f;
        throwTime = 0.0f;
        throwDuration = 0.8f;

        myWeapon = Instantiate(weapon, normalWeaponPos.position, Quaternion.identity) as GameObject;
        setNormalWeaponAttributes();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Time.time >= attackTime && isAttacking)
        {
            isAttacking = false;
            myAnim.SetBool("isAttacking", isAttacking);
            extraBodyParts.SetActive(false);
            setNormalWeaponAttributes();
        }
        if(Time.time >= throwTime && isThrowing)
        {
            myWeapon.SetActive(true);
            isThrowing = false;
            myAnim.SetBool("isThrowing", isThrowing);
        }

		if(Input.GetKey(KeyCode.W))
        {
            isRunning = true;
            myAnim.SetBool("isRunning", isRunning);
            Move(0.08f, 0.1f);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            isRunning = true;
            myAnim.SetBool("isRunning", isRunning);
            Move(-0.08f, -0.1f);
        }
        else if(Input.GetKeyDown(KeyCode.K) && !isAttacking && !isThrowing)
        {
            isAttacking = true;
            isRunning = false;
            myAnim.SetBool("isAttacking", isAttacking);
            attackTime = Time.time + attackDuration;
            extraBodyParts.SetActive(true);
            setAttackWeaponAttributes();
            Shoot();
        }
        else if(Input.GetKeyDown(KeyCode.T) && !isThrowing && !isAttacking)
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

    void Throw()
    {
        Instantiate(myGrenade, throwPos.position, Quaternion.identity);
        Instantiate(ground, new Vector2(transform.position.x + 8.97f, transform.position.y - 0.83f), Quaternion.identity);
    }

}
