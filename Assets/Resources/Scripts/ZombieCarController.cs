using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCarController : MonoBehaviour {

    public float speed;
    public Animator myAnim;
    private bool isDead;

	// Use this for initialization
	void Start () 
    {
        isDead = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(!isDead)
            Move();
	}

    void Move()
    {
        transform.position -= Vector3.right * speed * Time.deltaTime;
    }


    public void makeDead()
    {
        isDead = true;
        myAnim.SetBool("isDead", true);
        Destroy(transform.Find("body").GetComponent<BoxCollider2D>());
        Destroy(gameObject, 2.0f);
    }

    public void makeDeadByBoom()
    {
        if (!isDead)
        {
            isDead = true;
            foreach (Transform child in transform)
            {
                child.gameObject.GetComponent<AddForce>().Explode();
            }
            Destroy(gameObject, 2.5f);
        }
    }
}
