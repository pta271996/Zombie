using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBulletS : SBullet {

    public float angle;

    public GameObject bloodHit;
    public GameObject bloodSplatter;
    public GameObject shell;
    public GameObject bulletShell;

    // Use this for initialization
    void Start()
    {
        angle = transform.localEulerAngles.z;

        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = angle;
        transform.rotation = Quaternion.Euler(rotationVector);

        Instantiate(bulletShell, transform.position, bulletShell.transform.rotation);
    }


    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public override void Move()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(speed * Time.deltaTime, 0, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if (otherColl.tag == "zombie")
        {
            if (otherColl is BoxCollider2D)
            {
                if (otherColl.gameObject.GetComponent<SZombieFam>())
                    otherColl.gameObject.GetComponent<SZombieFam>().setDead();
                else if (otherColl.gameObject.GetComponent<SZombieJump>())
                    otherColl.gameObject.GetComponent<SZombieJump>().setDead();
                Instantiate(bloodSplatter, new Vector2(transform.position.x + 0.65f, transform.position.y - 0.375f), bloodSplatter.transform.rotation);
            }
            else if (otherColl is CircleCollider2D)
            {
                if (otherColl.gameObject.GetComponent<SZombieFam>())
                    otherColl.gameObject.GetComponent<SZombieFam>().setDeadByHeadShot();
                else if (otherColl.gameObject.GetComponent<SZombieJump>())
                    otherColl.gameObject.GetComponent<SZombieJump>().setDeadByHeadShot();
                Instantiate(bloodSplatter, new Vector2(transform.position.x + 0.65f, transform.position.y - 0.65f), bloodSplatter.transform.rotation);
            }

            Instantiate(bloodHit, new Vector2(transform.position.x - 0.15f, transform.position.y), bloodHit.transform.rotation);

            Destroy(gameObject);
        }

        if (otherColl.tag == "car" || otherColl.tag == "bike")
        {
            Instantiate(shell, transform.position, shell.transform.rotation);
            if (otherColl.GetComponent<CarBodyController>())
            {
                otherColl.GetComponent<CarBodyController>().ShowSparkPS(transform.position);
            }
            Destroy(gameObject);
        }

        if (otherColl.tag == "mirror")
        {
            Destroy(gameObject);
        }

        if (otherColl.tag == "zombie head")
        {
            Instantiate(bloodHit, new Vector2(transform.position.x - 0.15f, transform.position.y), bloodHit.transform.rotation);
            Destroy(gameObject);
        }
    }
}
