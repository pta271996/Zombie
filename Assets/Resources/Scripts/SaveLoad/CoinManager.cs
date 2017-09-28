using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {

    public static CoinManager coinManager;
    public int coin=0;

	// Use this for initialization
	void Awake() 
    {
        coinManager = this;
	}
	
	public void addCoin(int amount)
    {
        coin += amount;
    }

}
