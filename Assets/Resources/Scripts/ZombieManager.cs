using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ZombieTypeAndLevel {
	public GameObject zombie;
	public int level;
}
public class ZombieManager :Singleton<ZombieManager> {

	public Transform parentTranform;
	public int numberZombie;//so luong zombie
	public float maxYPosition; //vi tri cao nhat zombie co the xuat hien truc Y
	public float minYPosition; //vitri thap nhat zombie co the xuat hien truc Y
	public float maxXPosition; // vi tri zombie xuat hien theo truc X (thong thuong xa nhat man hinh )
	public ZombieTypeAndLevel[] zombieTypes;

	//danh sach zombie duoc khoi tao
	private List<SZombie> zombiesList;
	void Awake(){
		zombiesList = new List<SZombie>();
	}
	// Use this for initialization
	void Start(){

	}
	public GameObject createZombie(GameObject ori, Vector3 pos){
		return Instantiate (ori, pos, Quaternion.identity);
	}


	// Update is called once per frame
	void Update () {

	}

	public List<SZombie> ZombiesList {
		get{
			return this.zombiesList;
		}
		set{
			this.zombiesList = value;
		}
	}

}
