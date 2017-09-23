using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {

    public GameObject bomb;
    public GameObject smoke;
    public float shootTime;
    public float shootDuration;
    public float stopShootDuration;
    public Transform gunTip;
    public Animator myAnim;

    private bool isShooting;

	// Use this for initialization
	void Start () 
    {
        isShooting = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Time.time >= shootTime && isShooting)
        {
            isShooting = false;
            myAnim.SetBool("isShooting", false);
        }

		if(Time.time >= (shootTime + stopShootDuration) && !isShooting)
        {
            isShooting = true;
            myAnim.SetBool("isShooting", true);
            Invoke("Shoot", 0.4f);
            shootTime = Time.time + shootDuration;
        }
	}

    void Shoot()
    {
        Instantiate(bomb, gunTip.position, bomb.transform.rotation);
        Instantiate(smoke, gunTip.position, bomb.transform.rotation);
    }
}
