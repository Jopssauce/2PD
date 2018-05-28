using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {
	public float moveSpeed = 2;
	public Vector3 direction;
	// Update is called once per frame
	void FixedUpdate () 
	{
		direction.x = 0;
		direction.y = 1;
		//GetComponent<Rigidbody2D>().velocity = transform.up * 6;
		this.transform.position += transform.up * moveSpeed * Time.deltaTime;
		Destroy(this.gameObject, 2.0f);
	}
	void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.GetComponent<PlayerStats>()) 
		{
			col.gameObject.GetComponent<PlayerStats>().DeductHp(5);
		}
		
        Destroy(gameObject);
    }
}
