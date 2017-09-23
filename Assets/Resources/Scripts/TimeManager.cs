using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    public Image imgPause;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void doPause(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0.0f;
            imgPause.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else
        {

        }

    }
}
