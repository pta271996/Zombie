using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//lop GameManager de quan ly cac hoat dong chung trong game bao gom Zombie, Player,...
//dong vai tro dieu khien, tuong tac trung gian giua cac lop zombie, player, voi cac lop ZombieManager, BulletManager,..
public class GameManager : Singleton<GameManager> {

	public int levelScene; //man choi : 1, 2, 3 ,4...

    private int zombieNum;
    private int currentDeadZombieNum;

    public GameObject upperPanel;
    public GameObject lowerPanel;
    public GameObject middlePanel;

	void Awake(){

	}
	// Use this for initialization
	void Start () 
    {
        zombieNum = GetComponent<ZombieManager>().numberZombie;
        currentDeadZombieNum = 0;
	}

	// Update is called once per frame
	void Update () {

	}

    public void increaseDeadZombieNum()
    {
        currentDeadZombieNum++;
        if (currentDeadZombieNum >= zombieNum)
            Invoke("makeWin", 2.5f);
    }

    public void makeWin()
    {
        middlePanel.SetActive(true);
        upperPanel.SetActive(false);
        lowerPanel.SetActive(false);
    }

    public void makeLose()
    {

    }
}
