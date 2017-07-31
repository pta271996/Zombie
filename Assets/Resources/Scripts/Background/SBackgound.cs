using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBackgound : MonoBehaviour {

	protected SpriteRenderer sprite;
	void Awake(){
		sprite = GetComponent<SpriteRenderer> ();
	}
	public void matchCamera(){
		float scaleX = CameraController.Instance.Horizontal / sprite.bounds.size.x ;
		float scaleY =  CameraController.Instance.Vertical / sprite.bounds.size.y ;
		this.transform.localScale = new Vector3 (scaleX, scaleY, transform.localScale.z);

	}
}
