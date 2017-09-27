using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenShieldController : MonoBehaviour {

    private GameObject shieldPiece1;
    private GameObject shieldPiece2;

	// Use this for initialization
	void Start () 
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        soundManager.GetComponent<SoundsManager>().playBrokenGlassSound();
        shieldPiece1 = transform.GetChild(0).gameObject;
        shieldPiece2 = transform.GetChild(1).gameObject;

        shieldPiece1.GetComponent<Rigidbody2D>().AddForce(new Vector2(-3.0f, 3.5f), ForceMode2D.Impulse);
        shieldPiece1.GetComponent<Rigidbody2D>().AddTorque(5.0f);
        shieldPiece2.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2.75f, 3.0f), ForceMode2D.Impulse);
        shieldPiece2.GetComponent<Rigidbody2D>().AddTorque(5.0f);
        Destroy(gameObject, 0.75f);
	}
	
	
}
