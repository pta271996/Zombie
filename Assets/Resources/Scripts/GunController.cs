using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public Transform shootPos;
    public float normalAngle;
    public float attackAngle;
    public GameObject bullet;
    public GameObject muzzleFlash;
    public GameObject bulletShell;


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
        Instantiate(bullet, shootPos.position, bullet.transform.rotation);
        Instantiate(muzzleFlash, shootPos.position, muzzleFlash.transform.rotation);
        Instantiate(bulletShell, new Vector3(shootPos.position.x,shootPos.position.y,0.0f), bulletShell.transform.rotation);
    }

}
