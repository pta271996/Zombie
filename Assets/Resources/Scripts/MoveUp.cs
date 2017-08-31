using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour {

    public float offsetY;

	public void Move()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + offsetY);
    }

}
