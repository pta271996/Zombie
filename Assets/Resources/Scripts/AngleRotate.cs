using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleRotate : MonoBehaviour {

    public float angleRange;
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.eulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * speed, angleRange) - angleRange / 2);
	}
}
