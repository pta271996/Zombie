using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public float speed;
    public GameObject dustSmoke;
    public GameObject ballPieces;

	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        Move();
	}

    void Move()
    {
        transform.position -= Vector3.right * Time.deltaTime * speed;
    }

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if(otherColl.tag == "obstacle")
        {
            otherColl.gameObject.GetComponent<SObstacle>().getDamaged(3);
            Instantiate(dustSmoke, transform.position, dustSmoke.transform.rotation);
            Instantiate(ballPieces, transform.position, ballPieces.transform.rotation);
            Destroy(gameObject);
        }
    }
}
