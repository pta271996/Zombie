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
    public Animator myAnim;
    public float shootDuration;
    public float shootAnimSpeed;

	// Use this for initialization
	void Start () 
    {
        setNormalAngle();
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void setNormalLayerOrder()
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 3;
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
        myAnim.SetBool("isShooting", true);
        Instantiate(bullet, shootPos.position, bullet.transform.rotation);
        if(muzzleFlash)
            Instantiate(muzzleFlash, muzzlePos.position, muzzleFlash.transform.rotation);
        if(bulletShell)
            Instantiate(bulletShell, new Vector3(muzzlePos.position.x, muzzlePos.position.y, 0.0f), bulletShell.transform.rotation);
    }

    public void setNormalAnim()
    {
        myAnim.SetBool("isShooting", false);
    }

    public float getShootDuration()
    {
        return shootDuration;
    }

    public float getShootAnimSpeed()
    {
        return shootAnimSpeed;
    }
    
}
