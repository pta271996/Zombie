using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController : MonoBehaviour {

    public float speed;
    public GameObject bullet;
    public GameObject muzzleFlash;
    public Transform gunTip1;
    public Transform gunTip2;
    public float shootTime;
    public float shootDuration;
    public float stopShootDuration;
    public GameObject gun;
    public Animator myAnim;

    private float firstPosX;
    private float lasePosX;
    private Vector3 firstPos;
    private Vector3 lastPos;
    private float posY;
    private bool isMovingRight;
    private bool isShooting;

	// Use this for initialization
	void Start () 
    {
        posY = 2.86f;
        firstPosX = -3.47f;
        lasePosX = 5.26f;
        firstPos = new Vector3(firstPosX, transform.position.y, transform.position.z);
        lastPos = new Vector3(lasePosX, transform.position.y, transform.position.z);

        isMovingRight = true;
        isShooting = false;

        shootTime = Time.time + shootTime;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (isMovingRight)
            transform.position += Vector3.right * Time.deltaTime * speed;
        else
            transform.position -= Vector3.right * Time.deltaTime * speed;

        if(isMovingRight && Vector3.Distance(transform.position,lastPos) <= 0.1f)
        {
            isMovingRight = false;
        }

        if(!isMovingRight && Vector3.Distance(transform.position,firstPos) <= 0.1f)
        {
            isMovingRight = true;
        }

        if(Time.time >= shootTime && isShooting)
        {
            muzzleFlash.SetActive(false);
            isShooting = false;
            myAnim.SetBool("isShooting", false);
        }

        if(Time.time >= (shootTime + stopShootDuration) && !isShooting)
        {
            Shoot();
            isShooting = true;
            myAnim.SetBool("isShooting", true);
            shootTime = Time.time + shootDuration;
        }
	}

    void Shoot()
    {
        muzzleFlash.SetActive(true);
        Instantiate(bullet, gunTip1.position, Quaternion.Euler(new Vector3(0, 0, gun.transform.localEulerAngles.z-90f)));
        Instantiate(bullet, gunTip2.position, Quaternion.Euler(new Vector3(0, 0, gun.transform.localEulerAngles.z-90f)));
    }
}
