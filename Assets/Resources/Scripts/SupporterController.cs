using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupporterController : MonoBehaviour {

    public GameObject aimingSystem;
    public float aimingSpeed;    
    public Animator myAnim;
    public GameObject bullet;
    public Transform gunTip;
    public Transform muzzlePos;
    public GameObject muzzleFlash;
    public float shootDistance;

    private GameObject enemy;
    private bool isAiming;
    private bool isShooting;
    private bool canShoot;
    private float shootTime;
    private float shootDuration;

	// Use this for initialization
	void Start () 
    {
        isAiming = false;
        isShooting = false;
        canShoot = false;

        shootTime = 0.0f;
        shootDuration = 0.3f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (enemy == null)
        {
            if (Time.time >= shootTime && isShooting)
            {
                isShooting = false;
                myAnim.SetBool("isShooting", false);
            }

            isAiming = false;
            return;
        }           
		
        if(Time.time >= shootTime && isShooting)
        {
            isShooting = false;
            myAnim.SetBool("isShooting", false);
        }

        Vector3 dir = enemy.transform.position - aimingSystem.transform.position;
        dir.Normalize();
        Debug.Log(enemy.name);

        if (Vector3.Distance(aimingSystem.transform.position, enemy.transform.position) <= shootDistance)
            canShoot = true;

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        Debug.Log(zAngle);

        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

        if(zAngle >= -50.0f && zAngle <= 45.0f)
            aimingSystem.transform.rotation = Quaternion.RotateTowards(aimingSystem.transform.rotation, desiredRot, aimingSpeed * Time.deltaTime);
       
        if(!isShooting && Time.time >= shootTime && canShoot)
        {
            isShooting = true;
            myAnim.SetBool("isShooting", true);
            shootTime = Time.time + shootDuration;
            Shoot();
        }
	}

    void Shoot()
    {
        Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, aimingSystem.transform.localEulerAngles.z)));
        Instantiate(muzzleFlash, muzzlePos.position, Quaternion.Euler(new Vector3(0, 0, aimingSystem.transform.localEulerAngles.z)));
    }

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if(otherColl.tag == "zombie" && !isAiming)
        {
            enemy = otherColl.gameObject;
            isAiming = true;
        }
    }

    void OnTriggerExit2D(Collider2D otherColl)
    {
        if (otherColl.tag == "zombie")
        {
            enemy = null;
            isAiming = false;
            canShoot = false;
        }
    }
}
