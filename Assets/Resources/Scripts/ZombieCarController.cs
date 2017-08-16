using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCarController : MonoBehaviour {

    public float speed;
    public Animator myAnim;
    private bool isMoving;

	// Use this for initialization
	void Start () 
    {
        isMoving = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(isMoving)
            Move();
	}

    void Move()
    {
        transform.position -= Vector3.right * speed * Time.deltaTime;
    }


    public void makeDead()
    {
        isMoving = false;
        myAnim.SetBool("isDead", true);
        Destroy(gameObject, 2.0f);
    }

    public void makeDeadByBoom()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<AddForce>().Explode();
        }
        Destroy(gameObject, 2.5f);
    }
}
