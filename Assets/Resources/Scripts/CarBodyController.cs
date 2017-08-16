using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBodyController : MonoBehaviour {

    public GameObject sparkPS;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void ShowSparkPS(Vector3 hitPos)
    {
        sparkPS.SetActive(true);
        sparkPS.transform.position = new Vector3(hitPos.x, hitPos.y, 0.0f);
        Invoke("HideSparkPS", 0.9f);
    }

    void HideSparkPS()
    {
        sparkPS.SetActive(false);
    }
}
