using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFollow : MonoBehaviour {

    public Transform shell;
    public float speed;


	// Update is called once per frame
	void Update () 
    {
        if(shell)
            Follow();
	}

    void Follow()
    {
        Vector3 NewPos = new Vector3(shell.position.x, transform.position.y, 0);
        this.transform.position = Vector3.Lerp(transform.position, NewPos, Time.deltaTime*speed); 
    }
}
