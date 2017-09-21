using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public Transform shootPos;
    public Transform muzzlePos;
    public float normalAngle;
    public float attackAngle;
    public GameObject bullet;
    public GameObject muzzleFlash;
    public GameObject bulletShell;
    public GameObject brain;
    public Animator myAnim;
    public float shootDuration;
    public float shootAnimSpeed;
    public Transform brainPos;

    private int bulletNum;
    public int bulletsPerShot;

    private float brainAngle;

	// Use this for initialization
	void Start () 
    {
        setNormalAngle();
        brainAngle = -75.0f;
        bulletNum = 80;
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void setNormalLayerOrder()
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
    }

    public void setAttackLayerOrder()
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 6;
    }

    public void setNormalAngle()
    {
        transform.rotation = Quaternion.identity;
        transform.Rotate(Vector3.forward * normalAngle);
    }

    public void setAttackAngle()
    {
        transform.rotation = Quaternion.identity;
        transform.Rotate(Vector3.forward * attackAngle);
    }

    public void setNormalPosition(Transform normalPos)
    {
        transform.parent = normalPos;
    }

    public void setAttackPosition(Transform attackPos)
    {
        transform.parent = attackPos;
    }

    public void Shoot()
    {
        if (bulletNum > 0)
        {
            bulletNum -= bulletsPerShot;
            myAnim.SetBool("isShooting", true);
            Instantiate(bullet, shootPos.position, bullet.transform.rotation);
            if (muzzleFlash)
                Instantiate(muzzleFlash, muzzlePos.position, muzzleFlash.transform.rotation);
            if (bulletShell)
                Instantiate(bulletShell, new Vector3(muzzlePos.position.x, muzzlePos.position.y, 0.0f), bulletShell.transform.rotation);
        }
    }

    public void PowerShoot()
    {
        myAnim.SetBool("isPowerShooting", true);
        Instantiate(brain, brainPos.position, Quaternion.Euler(new Vector3(0, 0, brainAngle)));
        brainAngle += 5.0f;
    }

    public void setNormalAnim()
    {
        myAnim.SetBool("isShooting", false);
        myAnim.SetBool("isPowerShooting", false);
        brainAngle = -75.0f;
    }


    public float getShootDuration()
    {
        return shootDuration;
    }

    public float getShootAnimSpeed()
    {
        return shootAnimSpeed;
    }
    

    public void setBulletNum(int num)
    {
        if(num >= 0)
            bulletNum = num;
    }

    public int getBulletNum()
    {
        return bulletNum;
    }

    public void setBulletsPerShot(int num)
    {
        if (num >= 1)
            bulletsPerShot = num;
    }

    public int getBulletsPerShot()
    {
        return bulletsPerShot;
    }
}
