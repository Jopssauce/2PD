using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {
	public float moveSpeed = 2;
	public float damage;
	public Vector2 direction;
	public float knocbackForce = 0.5f;
	// Update is called once per frame
	void FixedUpdate () 
	{
		//GetComponent<Rigidbody2D>().velocity = transform.up * 6;
		this.transform.position += transform.up * moveSpeed * Time.deltaTime;
		Destroy(this.gameObject, 2.0f);
	}
	void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.GetComponentInParent<PlayerStats>()) 
		{
			col.gameObject.GetComponentInParent<PlayerStats>().DeductHp(5);
			col.gameObject.GetComponentInParent<Rigidbody2D>().AddForce(direction * knocbackForce, ForceMode2D.Force);
		}
		
        Destroy(gameObject);
    }
}
