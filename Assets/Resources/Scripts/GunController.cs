using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    //public Transform normalPos;
    //public Transform attackPos;
    public Transform shootPos;
    public float normalAngle;
    public float attackAngle;
    public GameObject bullet;
    public GameObject muzzleFlash;


	// Use this for initialization
	void Start () 
    {
        setNormalAngle();
        setAttackAngle();
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
        //transform.position = normalPos.position;
        transform.parent = normalPos;
    }

    public void setAttackPosition(Transform attackPos)
    {
        //transform.position = attackPos.position;
        transform.parent = attackPos;
    }

    public void Shoot()
    {
        Instantiate(bullet, shootPos.position, bullet.transform.rotation);
        Instantiate(muzzleFlash, shootPos.position, bullet.transform.rotation);
    }

}
