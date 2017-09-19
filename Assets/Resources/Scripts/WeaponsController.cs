using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsController : MonoBehaviour {

    public Image imgWP1;
    public Image imgWP2;
    public Image imgWP3;

    private string weapon1;
    private string weapon2;
    private string weapon3;

    private int currentWP;


	// Use this for initialization
	void Start () 
    {
        weapon1 = "ak-47";
        weapon2 = "battery gun";
        weapon3 = "bazooka";

        currentWP = 3;
        setCurrentWeaponImage();
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void setWeapon1(string strWeapon)
    {
        weapon1 = strWeapon;
    }

    public void setWeapon2(string strWeapon)
    {
        weapon2 = strWeapon;
    }

    public void setWeapon3(string strWeapon)
    {
        weapon3 = strWeapon;
    }


    public string getWeapon1()
    {
        return weapon1;
    }

    public string getWeapon2()
    {
        return weapon2;
    }

    public string getWeapon3()
    {
        return weapon3;
    }


    public void setCurrentWeapon(int num)
    {
        if (num >= 1 && num <= 3)
        {
            currentWP = num;
            setCurrentWeaponImage();
        }
    }

    public int getCurrentWeapon()
    {
        return currentWP;
    }

    public string getCurrentWeaponString()
    {
        if (currentWP == 1)
            return weapon1;

        if (currentWP == 2)
            return weapon2;

        if (currentWP == 3)
            return weapon3;

        return null;
    }

    public void setCurrentWeaponImage()
    {
        if(currentWP == 1)
        {
            imgWP1.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            imgWP2.color = new Color(1.0f, 1.0f, 1.0f, 0.51f);
            imgWP3.color = new Color(1.0f, 1.0f, 1.0f, 0.51f);
        }

        if (currentWP == 2)
        {
            imgWP1.color = new Color(1.0f, 1.0f, 1.0f, 0.51f);
            imgWP2.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            imgWP3.color = new Color(1.0f, 1.0f, 1.0f, 0.51f);
        }

        if (currentWP == 3)
        {
            imgWP1.color = new Color(1.0f, 1.0f, 1.0f, 0.51f);
            imgWP2.color = new Color(1.0f, 1.0f, 1.0f, 0.51f);
            imgWP3.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }

    public void switchWeapon()
    {
        currentWP++;
        if (currentWP > 3)
            currentWP = 1;
        setCurrentWeaponImage();
    }
}
