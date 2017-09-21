using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerController : MonoBehaviour {

    public Image powerBG;
    public Image powerBar;

    private float powerNum;
    private float maxPowerNum = 1.0f;
    private float speed = 20.0f;


	// Use this for initialization
	void Start () 
    {
        powerNum = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void resetPowerNum()
    {     
        powerNum = 0.0f;
        float currentFill = powerNum / maxPowerNum;
        powerBar.fillAmount = currentFill;
        powerBar.GetComponent<Animator>().SetBool("isFull", false);
    }

    public float getPowerNum()
    {
        return powerNum;
    }

    public void increasePower()
    {
        powerNum = powerNum + 0.2f;
        if (powerNum >= maxPowerNum)
        {
            powerNum = maxPowerNum;
            powerBar.GetComponent<Animator>().SetBool("isFull", true);
            powerBar.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }

        float currentFill = powerNum / maxPowerNum;
        powerBar.fillAmount = currentFill;
    }

    public bool isFull()
    {
        return (powerNum >= maxPowerNum);
    }
}
