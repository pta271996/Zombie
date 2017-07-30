using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//lôop SBullet la lop cha chi chua cac thuoc tinh khoi tao
//khong dung ham start() hay update() cung nhu Awake trong lop nay
//chi chua cac thuoc tinh va phuong thuc
public class SBullet : MonoBehaviour {


	public float speed;
	public int damage;
	public virtual void Move()
	{
		transform.position += Vector3.right * Time.deltaTime * speed;
	}
	public int getDamage()
	{
		return damage;
	}

}
