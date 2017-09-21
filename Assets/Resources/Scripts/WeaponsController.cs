using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsController : MonoBehaviour {

    public Image imgWP1;
    public Image imgWP2;
    public Image imgWP3;

    public Text txtBulletNum1;
    public Text txtBulletNum2;
    public Text txtBulletNum3;

    private string weapon1;
    private string weapon2;
    private string weapon3;

    private int currentWP;


	// Use this for initialization
	void Start () 
    {
        weapon1 = "ak-47";
        weapon2 = "battery gun";
        weapon3 = "bubble gun";

        currentWP = 1;
        setWeaponIcon();
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

        return weapon1;
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

    public void setWeaponIcon()
    {
        imgWP1.sprite = Resources.Load<Sprite>("Graphic/UI/" + weapon1+ " icon");
        imgWP2.sprite = Resources.Load<Sprite>("Graphic/UI/" + weapon2 + " icon");
        imgWP3.sprite = Resources.Load<Sprite>("Graphic/UI/" + weapon3 + " icon");
    }

    public void switchWeapon()
    {
        currentWP++;
        if (currentWP > 3)
            currentWP = 1;
        setCurrentWeaponImage();
    }

    public void setTextBulletNum(int num)
    {
        if (currentWP == 1)
        {
            txtBulletNum1.text = num.ToString();
        }

        if (currentWP == 2)
        {
            txtBulletNum2.text = num.ToString();
        }

        if (currentWP == 3)
        {
            txtBulletNum3.text = num.ToString();
        }
    }
}
