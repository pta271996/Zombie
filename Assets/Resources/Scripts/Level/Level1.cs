using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : Singleton<Level1>, RandomInterface{

	public int lineNumber;
    public float spawnDuration;

	void Start(){
		InitZombies (lineNumber);
		//summonObstacles (lineNumber);

	}
	public void InitZombies(int lineNumber){
		float distance = (Mathf.Abs(ZombieManager.Instance.maxYPosition - ZombieManager.Instance.minYPosition)/lineNumber);
		StartCoroutine (summonZombies(lineNumber, distance));
	}
	//trieu hoi zombie
	IEnumerator summonZombies(int lineNumber, float distanceBetween2Zombies){


		float posY = randomPositionY (ZombieManager.Instance.minYPosition,ZombieManager.Instance.maxYPosition, distanceBetween2Zombies);
		int type = Random.Range (0, ZombieManager.Instance.zombieTypes.Length);
		GameObject cloneZombie = ZombieManager.Instance.createZombie ( ZombieManager.Instance.zombieTypes[type].zombie, new Vector3 ( ZombieManager.Instance.maxXPosition,posY, ZombieManager.Instance.zombieTypes[type].zombie.transform.position.z ));
		cloneZombie.transform.localScale = new Vector3 (cloneZombie.transform.localScale.x * -1, cloneZombie.transform.localScale.y, cloneZombie.transform.localScale.z);

		int line = (int)Mathf.Round((Mathf.Abs(posY-ZombieManager.Instance.maxYPosition)/distanceBetween2Zombies + 1));
        
		cloneZombie.GetComponent<SpriteRenderer> ().sortingOrder = line+6; //tinh line
		//Debug.Log ((int)Mathf.Round((Mathf.Abs(posY-ZombieManager.Instance.maxYPosition)/distanceBetween2Zombies + 1)));
		cloneZombie.transform.SetParent (ZombieManager.Instance.parentTranform);

		//get script
		SZombie zombieScript = cloneZombie.GetComponent<SZombie> ();
		ZombieManager.Instance.ZombiesList.Add (zombieScript);

		//Setup cac thuoc tinh cho zombie theo level
		zombieScript.SetUp( ZombieManager.Instance.zombieTypes[type].level,line);

        yield return new WaitForSeconds(spawnDuration);
		if( ZombieManager.Instance.ZombiesList.Count <  ZombieManager.Instance.numberZombie)
			StartCoroutine (summonZombies(lineNumber,distanceBetween2Zombies));
	}
	void summonObstacles(int lineNumber){ //Mathf.Abs(maxXPosition - minYPosition) >=0
		float distancePerOne = (Mathf.Abs(ObstacleManager.Instance.maxYPosition - ObstacleManager.Instance.minYPosition)/lineNumber);

		summonStrikes (lineNumber, distancePerOne);
		//summonMetalBlock (lineNumber, distancePerOne);

	}


	void summonStrikes (int lineNumber, float distancePerOne){
		for (int i = 0; i < lineNumber; i++) {
			float posY = ObstacleManager.Instance.maxYPosition -  i * distancePerOne; //vi tri line ( tu 1 ,2 ,... lineNumber-1)
			float posX = ObstacleManager.Instance.minXPosition + (lineNumber - i - 1) * 0.3f; //vi tri X
			int type = 0; //random loai Obstacle
			summonAObstacle(i,type,posX, posY);

		}

	}


	void summonAObstacle(int line,int type,float posX,  float posY){
		//tao Obstacle 
		GameObject cloneObstacle = ObstacleManager.Instance.createObstacle ( ObstacleManager.Instance.obstacleTypes[type].obstacle, new Vector3 ( posX,posY, ObstacleManager.Instance.obstacleTypes[type].obstacle.transform.position.z ));
		//chinh sua scale cho phu hop
		cloneObstacle.transform.localScale = new Vector3 (cloneObstacle.transform.localScale.x * -1, cloneObstacle.transform.localScale.y, cloneObstacle.transform.localScale.z);

		//chinh sorting de hien thi chinh xac hinh anh theo thu tu
		cloneObstacle.GetComponent<SpriteRenderer> ().sortingOrder = line + 1;
		//set Parent
		cloneObstacle.transform.SetParent ( ObstacleManager.Instance.parentTranform);

		//get script
		SObstacle obstacleScript = cloneObstacle.GetComponent<SObstacle> ();
		ObstacleManager.Instance.ObstaclesList.Add (obstacleScript);

		//Setup cac thuoc tinh cho zombie theo level
		obstacleScript.SetUp(ObstacleManager.Instance.obstacleTypes[type].level, line + 1); //setup level and line
	}


	//random vi tri cua zombie theo chieu doc ( truc Y )
	public float randomPositionY(float minYPosition,float maxYPosition,float distance) { 
		//distance la khoang cach toi thieu ma 2 con zombie cach nhau theo chieu doc Y
		//vd  zombie1.position.y = -1.4 thi zombie2.position.y = -1.6 hoac -1.8 hoac -2.0 tuy vao random

		//int maxCount =  (int)(Mathf.Abs(maxYPosition - minYPosition)/distance); //Mathf.Abs(maxXPosition - minYPosition) >=0

		int rand = Random.Range(0, lineNumber);
		//Debug.Log ("Random line : " + rand);
		float rs = maxYPosition - distance * rand; //distance * rand >= 0
		//Debug.Log(rs + " " + " " + maxYPosition+ " " +  distance * rand);
		return rs;

	}

}
