using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour 
{
	public float damage;
	public Vector2 direction;
	public float knocbackForce = 0.5f;
	void Start()
	{
		Destroy(this.gameObject, 0.1f);
	}
	
	public void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log(col);
		if(col.gameObject.GetComponentInParent<Health>())
		{
			GetComponent<DamageActor>().DealDamage(damage, col.gameObject, GetComponent<DamageActor>().damageType);
			col.gameObject.GetComponentInParent<Rigidbody2D>().AddForce(direction * knocbackForce, ForceMode2D.Force);
		}
		
	}
}
