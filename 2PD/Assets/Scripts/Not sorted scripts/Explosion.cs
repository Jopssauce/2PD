using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour 
{
	DamageActor damageActor;
	public Collider2D[] entities;
	public float radius = 0.7f;
	public float explosionForce = 50;
	public float damage = 10;
	void Start()
	{
		damageActor = GetComponent<DamageActor> ();
		entities = Physics2D.OverlapCircleAll (transform.position, radius);

		foreach (var item in entities) 
		{
			if (item.GetComponent<Health> ()) 
			{
				damageActor.DealDamage (damage, item.gameObject, DamageActor.DamageTypes.standard);
				if (item.GetComponent<Rigidbody2D>()) 
				{
					
				}
			}
		}
		Destroy (this.gameObject, 1);
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, radius);
	}
}
