using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMowerController : MonoBehaviour {

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
        if (!isDead)
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
        Destroy(transform.Find("body").GetComponent<PolygonCollider2D>());
        Destroy(gameObject, 2.0f);
    }

    public void makeDeadByBoom()
    {
        if (!isDead)
        {
            isDead = true;
            myAnim.SetBool("isDeadByBoom", true);
            foreach (Transform child in transform)
            {
                if(child.gameObject.GetComponent<AddForce>())
                child.gameObject.GetComponent<AddForce>().Explode();
            }

            GameObject leg1 = transform.Find("leg 1").gameObject;
            GameObject lowerLeg1 = leg1.transform.GetChild(1).gameObject;
            leg1.transform.GetChild(0).GetComponent<AddForce>().Explode();
            lowerLeg1.transform.GetChild(0).GetComponent<AddForce>().Explode();
            lowerLeg1.transform.GetChild(1).GetComponent<AddForce>().Explode();

            GameObject leg2 = transform.Find("leg 2").gameObject;
            GameObject lowerLeg2 = leg2.transform.GetChild(1).gameObject;
            leg2.transform.GetChild(0).GetComponent<AddForce>().Explode();
            lowerLeg2.transform.GetChild(0).GetComponent<AddForce>().Explode();
            lowerLeg2.transform.GetChild(1).GetComponent<AddForce>().Explode();

            Destroy(gameObject, 2.5f);
        }
    }
}
