using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController> {

	// Use this for initialization
	private float horizontal;
	private float vertical;

	void Awake(){
		horizontal = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0)).x - Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0)).x;
		vertical = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0)).y - Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0)).y;

	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public float Horizontal {
		get {
			return this.horizontal;
		}
		set{
			this.horizontal = value;
		}
	}
	public float Vertical {
		get {
			return this.vertical;
		}
		set{
			this.vertical = value;
		}
	}
}
