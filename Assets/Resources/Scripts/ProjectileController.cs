using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public int damage;
    public float speed;
    public GameObject hitEffect;
    public GameObject hitEffect2;

	// Use this for initialization
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
        transform.position += Vector3.right * Time.deltaTime * speed;
    }

    public int getDamage()
    {
        return damage;
    }


    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if(otherColl.tag == "zombie")
        {
            GameObject soundManager = GameObject.Find("SoundManager");
            if (gameObject.name == "cocktail(Clone)")
                soundManager.GetComponent<SoundsManager>().playBrokenGlassSound();
            else
                soundManager.GetComponent<SoundsManager>().playProjectileHitSound();
            if (hitEffect)
                Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
            if (hitEffect2)
                Instantiate(hitEffect2, transform.position, hitEffect2.transform.rotation);
            Destroy(gameObject);
        }

        if(otherColl.tag == "car" || otherColl.tag == "mirror" || otherColl.tag == "mower")
        {
            Destroy(gameObject);
        }

        if(otherColl.tag == "zombie head")
        {
            if (hitEffect)
                Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
            if (hitEffect2)
                Instantiate(hitEffect2, transform.position, hitEffect2.transform.rotation);
        }
    }




}
