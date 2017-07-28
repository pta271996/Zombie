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
	public void Init(){
		
		StartCoroutine (summon ());
	}
	//trieu hoi zombie
	IEnumerator summon(){
		
		float posY = randomPositionY (minYPosition, maxYPosition, 0.2f);
		int type = randomTypeZombie ();
		GameObject cloneZombie = createZombie (zombieTypes[type].zombie, new Vector3 (maxXPosition,posY,zombieTypes[type].zombie.transform.position.z ));
		cloneZombie.transform.localScale = new Vector3 (cloneZombie.transform.localScale.x * -1, cloneZombie.transform.localScale.y, cloneZombie.transform.localScale.z);
		cloneZombie.transform.SetParent (parentTranform);

		//get script
		SZombie zombieScript = cloneZombie.GetComponent<SZombie> ();
		zombiesList.Add (cloneZombie.GetComponent<SZombie> ());

		//Setup cac thuoc tinh cho zombie theo level
		zombieScript.SetUp(zombieTypes[type].level);

		yield return new WaitForSeconds (2.5f);
		if(zombiesList.Count < numberZombie)
		StartCoroutine (summon ());
	}
	GameObject createZombie(GameObject ori, Vector3 pos){
		return Instantiate (ori, pos, Quaternion.identity);
	}

	//random vi tri cua zombie theo chieu doc ( truc Y )
	float randomPositionY(float minYPosition,float maxYPosition,float distance) { 
		//distance la khoang cach toi thieu ma 2 con zombie cach nhau theo chieu doc Y
		//vd  zombie1.position.y = -1.4 thi zombie2.position.y = -1.6 hoac -1.8 hoac -2.0 tuy vao random
		int maxCount =  (int)(Mathf.Abs(maxYPosition - minYPosition)/distance); //Mathf.Abs(maxXPosition - minYPosition) >=0
		int rand = Random.Range(0, maxCount);
		float rs = maxYPosition - distance * rand; //distance * rand >= 0
		//Debug.Log(rs + " " + " " + maxYPosition+ " " +  distance * rand);
		return rs;

	}
	int randomTypeZombie(){
		int number = zombieTypes.Length;
		int rand = Random.Range (0, number);
		return rand;
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
