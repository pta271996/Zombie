using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{

    public float speed;
    public Animator myAnim;
    public Rigidbody2D myRB;
    public Transform weaponPos;
    public Transform extraBodyPartsPos;

    private bool isRunning;
    private bool isAttacking;
    private bool isGettingHurted;

	// Use this for initialization
	void Start () 
    {
        isRunning = false;
        isAttacking = false;
        isGettingHurted = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
		if(Input.GetKey(KeyCode.W))
        {
            isRunning = true;
            myAnim.SetBool("isRunning", isRunning);
            Move(0.08f, 0.1f);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            isRunning = true;
            myAnim.SetBool("isRunning", isRunning);
            Move(-0.08f, -0.1f);
        }
        else
        {
            isRunning = false;
            myAnim.SetBool("isRunning", isRunning);
        }
	}

    void Move(float wInput, float hInput)
    {
        //myRB.velocity = new Vector2(myRB.velocity.x, hInput*speed);
        transform.position += Vector3.up * hInput * speed * Time.deltaTime;
        transform.position += Vector3.right * wInput * speed * Time.deltaTime;
    }

}
