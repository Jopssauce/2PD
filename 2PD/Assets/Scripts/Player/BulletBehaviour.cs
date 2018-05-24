using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		GetComponent<Rigidbody2D>().velocity = transform.up * 6;
		Destroy(this.gameObject, 2.0f);
	}
	void OnCollisionEnter2D(Collision2D col)
    {
		if (col.gameObject.GetComponent<PlayerStats>()) 
		{
			col.gameObject.GetComponent<PlayerStats>().Damage(5);
		}
		
        Destroy(gameObject);
    }
}
