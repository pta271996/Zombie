using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObstacleTypeAndLevel {
	public GameObject obstacle;
	public int level;
}

public class ObstacleManager : Singleton<ObstacleManager>  {

	public Transform parentTranform;
	//public int numberObstacle;//so luong zombie
	public float maxYPosition; //vi tri cao nhat zombie co the xuat hien truc Y
	public float minYPosition; //vitri thap nhat zombie co the xuat hien truc Y
	public float minXPosition; // vi tri zombie xuat hien theo truc X (thong thuong xa nhat man hinh )
	public ObstacleTypeAndLevel[] obstacleTypes;

	//danh sach zombie duoc khoi tao
	private List<SObstacle> obstaclesList;
	void Awake(){
		obstaclesList = new List<SObstacle>();
	}
	// Use this for initialization
	void Start(){

	}
	public GameObject createObstacle(GameObject ori, Vector3 pos){
		return Instantiate (ori, pos, Quaternion.identity);
	}


	// Update is called once per frame
	void Update () {

	}

	public List<SObstacle> ObstaclesList {
		get{
			return this.obstaclesList;
		}
		set{
			this.obstaclesList = value;
		}
	}
}
