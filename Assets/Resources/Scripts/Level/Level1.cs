using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : Singleton<Level1>, RandomInterface{


	void Start(){
		InitZombies ();
		summonObstacles ();
	}
	public void InitZombies(){

		StartCoroutine (summonZombies());
	}
	//trieu hoi zombie
	IEnumerator summonZombies(){

		float posY = randomPositionY (ZombieManager.Instance.minYPosition,ZombieManager.Instance.maxYPosition, 0.4f);
		int type = Random.Range (0, ZombieManager.Instance.zombieTypes.Length);
		GameObject cloneZombie = ZombieManager.Instance.createZombie ( ZombieManager.Instance.zombieTypes[type].zombie, new Vector3 ( ZombieManager.Instance.maxXPosition,posY, ZombieManager.Instance.zombieTypes[type].zombie.transform.position.z ));
		cloneZombie.transform.localScale = new Vector3 (cloneZombie.transform.localScale.x * -1, cloneZombie.transform.localScale.y, cloneZombie.transform.localScale.z);
		cloneZombie.transform.SetParent ( ZombieManager.Instance.parentTranform);

		//get script
		SZombie zombieScript = cloneZombie.GetComponent<SZombie> ();
		ZombieManager.Instance.ZombiesList.Add (zombieScript);

		//Setup cac thuoc tinh cho zombie theo level
		zombieScript.SetUp( ZombieManager.Instance.zombieTypes[type].level);

		yield return new WaitForSeconds (2.5f);
		if( ZombieManager.Instance.ZombiesList.Count <  ZombieManager.Instance.numberZombie)
			StartCoroutine (summonZombies());
	}
	void summonObstacles(){
		int maxCount =  (int)(Mathf.Abs(ObstacleManager.Instance.maxYPosition - ObstacleManager.Instance.minYPosition)/0.4f); //Mathf.Abs(maxXPosition - minYPosition) >=0

		for (int i = 0; i < maxCount; i++) {
			float posY = ObstacleManager.Instance.maxYPosition -  i * 0.4f;
			int type = Random.Range (0, ObstacleManager.Instance.obstacleTypes.Length);
			GameObject cloneObstacle = ObstacleManager.Instance.createObstacle ( ObstacleManager.Instance.obstacleTypes[type].obstacle, new Vector3 ( ObstacleManager.Instance.maxXPosition,posY, ObstacleManager.Instance.obstacleTypes[type].obstacle.transform.position.z ));
			cloneObstacle.transform.localScale = new Vector3 (cloneObstacle.transform.localScale.x * -1, cloneObstacle.transform.localScale.y, cloneObstacle.transform.localScale.z);
			cloneObstacle.transform.SetParent ( ObstacleManager.Instance.parentTranform);

			//get script
			SObstacle obstacleScript = cloneObstacle.GetComponent<SObstacle> ();
			ObstacleManager.Instance.ObstaclesList.Add (obstacleScript);

			//Setup cac thuoc tinh cho zombie theo level
			obstacleScript.SetUp(ObstacleManager.Instance.obstacleTypes[type].level);


		}

	}


	//random vi tri cua zombie theo chieu doc ( truc Y )
	public float randomPositionY(float minYPosition,float maxYPosition,float distance) { 
		//distance la khoang cach toi thieu ma 2 con zombie cach nhau theo chieu doc Y
		//vd  zombie1.position.y = -1.4 thi zombie2.position.y = -1.6 hoac -1.8 hoac -2.0 tuy vao random

		int maxCount =  (int)(Mathf.Abs(maxYPosition - minYPosition)/distance); //Mathf.Abs(maxXPosition - minYPosition) >=0

		int rand = Random.Range(0, maxCount);
		float rs = maxYPosition - distance * rand; //distance * rand >= 0
		//Debug.Log(rs + " " + " " + maxYPosition+ " " +  distance * rand);
		return rs;

	}

}
