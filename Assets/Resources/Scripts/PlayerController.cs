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
    public Transform normalWeaponPos;
    public Transform attackWeaponPos;

    private bool isRunning;
    private bool isAttacking;
    private bool isGettingHurted;
    private float attackTime;
    private float attackDuration;


	// Use this for initialization
	void Start () 
    {
        isRunning = false;
        isAttacking = false;
        isGettingHurted = false;

        attackTime = 0.0f;
        attackTime = 0.8f;

        Instantiate(weapon, normalWeaponPos.position, weapon.transform.rotation);
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
        else if(Input.GetKeyDown(KeyCode.K))
        {
            isAttacking = true;
            isRunning = false;
            myAnim.SetBool("isAttacking", isAttacking);
            attackTime = Time.time + attackDuration;
            extraBodyParts.SetActive(true);
            setAttackWeaponAttributes();
            Shoot();
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
        weapon.GetComponent<GunController>().setNormalAngle();
        weapon.GetComponent<GunController>().setNormalLayerOrder();
        weapon.GetComponent<GunController>().setNormalPosition(normalWeaponPos);
    }

    void setAttackWeaponAttributes()
    {
        weapon.GetComponent<GunController>().setAttackAngle();
        weapon.GetComponent<GunController>().setAttackLayerOrder();
        weapon.GetComponent<GunController>().setAttackPosition(attackWeaponPos);
    }

    void Shoot()
    {
        weapon.GetComponent<GunController>().Shoot();
    }

}
