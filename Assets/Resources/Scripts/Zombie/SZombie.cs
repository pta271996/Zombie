using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SZombie : MonoBehaviour {
	
	[SerializeField]
	protected float speed;// = 4.0f;
	[SerializeField]
	protected int health;// = 2;
	[SerializeField]
	protected float attackTime;// = 1.5f;
	[SerializeField]
	protected Animator myAnim;
    [SerializeField]
    protected Rigidbody2D myRB;

	protected bool isAttacking;
	protected bool isDead;

	public void Move()
	{
		transform.position -= Vector3.right * Time.deltaTime * speed;
	}
	public float getAttackTime()
	{
		return attackTime;
	}	

	public void stopAttack()
	{
		isAttacking = false;
		myAnim.SetBool("isAttacking",false);
	}

	public void getDamaged(int damage)
	{
		health -= damage;
        myRB.AddForce(new Vector2(5.0f, 0.0f), ForceMode2D.Impulse);
        Invoke("stopForce", 0.5f);
		if (health <= 0)
			makeDead ();
	}

    public void stopForce()
    {
        myRB.velocity = Vector2.zero;
    }

	public void makeDead()
	{
		isDead = true;
        Destroy(gameObject.GetComponent<CircleCollider2D>());
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        stopForce();
		myAnim.SetBool("isDead",true);
		Destroy (gameObject, 2.0f);
	}
	public float Speech{
		get{
			return this.speed;
		}
		set{
			this.speed = value;
		}
	}
	public int Health {
		get{
			return this.health;
		}
		set{
			this.health = value;
		}
	}
	public float AttackTime {
		get{
			return this.attackTime;
		}
		set{
			this.attackTime = value;
		}
	}
}
