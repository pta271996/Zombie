using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainController : MonoBehaviour {

    public float speed;    
    public Rigidbody2D myRB;
    public GameObject liquidSplash;

    private Quaternion firstRotation;
    private float angle;

	// Use this for initialization
	void Start () 
    {
        angle = Random.Range(-65.0f, -13.0f);

        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = angle;
        transform.rotation = Quaternion.Euler(rotationVector);
        firstRotation = transform.rotation;

        myRB.AddTorque(Random.Range(120.0f,160.0f));
	}
	
	// Update is called once per frame
	void Update () 
    {
        Move();
	}

    void Move()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(speed * Time.deltaTime, 0, 0);
        pos += firstRotation * velocity;
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if(otherColl.tag == "zombie")
        {
            Instantiate(liquidSplash, transform.position, liquidSplash.transform.rotation);
            Destroy(gameObject);
        }
    }
}
