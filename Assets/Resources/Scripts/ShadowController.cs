using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour {

    public Transform target;
    public float speed;
    public Animator myAnim;

    private bool isScaling;

	// Use this for initialization
	void Start () 
    {
        isScaling = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (target)
        {
            if(!isScaling)
                Follow();
        }           
        else
            Destroy(gameObject);
	}

    void Follow()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime*speed);
    }

    public void setScaling(bool scale)
    {
        isScaling = scale;
        myAnim.SetBool("isScaling", scale);
    }

}
