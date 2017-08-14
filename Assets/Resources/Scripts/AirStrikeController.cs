using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirStrikeController : MonoBehaviour 
{

    public float speed;
    public GameObject bomb;
    public Transform bombDropPos;
    public float dropTime;

	// Use this for initialization
	void Start () 
    {
        Invoke("DropBomb", dropTime);
	}
	
	// Update is called once per frame
	void Update () 
    {
        Move();
	}

    void Move()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
    }

    void DropBomb()
    {
        Instantiate(bomb, bombDropPos.position, bomb.transform.rotation);
    }
}
