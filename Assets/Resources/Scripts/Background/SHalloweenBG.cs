using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHalloweenBG : SBackgound {
	private SpriteRenderer sprite;
	// Use this for initialization
	void Awake(){
		sprite = GetComponent<SpriteRenderer> ();
	}

	void Start () {
		float scaleX = CameraController.Instance.Horizontal / sprite.bounds.size.x ;
		float scaleY =  CameraController.Instance.Vertical / sprite.bounds.size.y ;
		this.transform.localScale = new Vector3 (scaleX, scaleY, transform.localScale.z);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
