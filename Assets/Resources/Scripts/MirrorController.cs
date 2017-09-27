using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorController : MonoBehaviour {

    public string strSpriteName;
    public GameObject brokenMirror1;
    public GameObject brokenMirror2;
    private int state;

	// Use this for initialization
	void Start () 
    {
        state = 1;
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void getDamaged()
    {
        if (state >= 2)
        {
            makeDead();
        }
        else
        {
            state++;
            loadStateSprite();
        }
    }

    void loadStateSprite()
    {
        string strState = strSpriteName + state.ToString();
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Graphic/Car/" + strState);
    }

    void makeDead()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<SoundsManager>().playBrokenGlassSound();
        Destroy(gameObject.GetComponent<PolygonCollider2D>());
        Instantiate(brokenMirror1, transform.position, brokenMirror1.transform.rotation);
        Instantiate(brokenMirror2, transform.position, brokenMirror1.transform.rotation);
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D otherColl)
    {
        if(otherColl.tag == "bullet" || otherColl.tag == "projectile")
        {
            getDamaged();
        }
    }
}
