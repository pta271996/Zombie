using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//lop GameManager de quan ly cac hoat dong chung trong game bao gom Zombie, Player,...
//dong vai tro dieu khien, tuong tac trung gian giua cac lop zombie, player, voi cac lop ZombieManager, BulletManager,..
public class GameManager : Singleton<GameManager> {

	public int levelScene; //man choi : 1, 2, 3 ,4...

	void Awake(){

	}
	// Use this for initialization
	void Start () {
		ZombieManager.Instance.Init ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
