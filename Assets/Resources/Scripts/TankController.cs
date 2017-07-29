using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

    public Transform turretTip;
    public GameObject bullet;
    public GameObject fire;
    public float shootTime = 0.0f;
    public float stopShootDuration = 1.5f;


	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		if(Time.time >= shootTime)
        {
            shootTime = Time.time + stopShootDuration;
            Shoot();
        }
       
	}

    void Shoot()
    {
        Instantiate(bullet,turretTip.position,bullet.transform.rotation);
        Instantiate(fire, turretTip.position, bullet.transform.rotation);
        fire.SetActive(true);
    }
}
