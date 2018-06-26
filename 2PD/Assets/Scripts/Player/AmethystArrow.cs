using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmethystArrow : BulletBehaviour {
public float heal = 5;
void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.GetComponentInParent<PlayerStats>()) 
		{
			col.gameObject.GetComponentInParent<Health>().AddHp(heal);
			col.gameObject.GetComponentInParent<Rigidbody2D>().AddForce(direction * knocbackForce, ForceMode2D.Force);
		}
		
        Destroy(gameObject);
    }
}
