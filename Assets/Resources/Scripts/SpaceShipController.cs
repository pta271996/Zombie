using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour {

    public float speed;
    public Transform gunTip;
    public GameObject ray;
    public float shootTime = 0.0f;
    public float stopShootDuration = 1.5f;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Time.time >= shootTime)
        {
            shootTime = Time.time + stopShootDuration;
            Shoot();
        }

        Move();
	}

    void Move()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
    }

    void Shoot()
    {
        Instantiate(ray, gunTip.position, ray.transform.rotation);
    }
}
