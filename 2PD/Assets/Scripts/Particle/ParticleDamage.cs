using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamage : MonoBehaviour {

	public List<GameObject> objects;
	public List<ParticleCollisionEvent> collisionEvents;
	[Range(0,100)]
	public float knockbackForce = 5;

	void Start()
	{
		collisionEvents = new List<ParticleCollisionEvent>();
	}

	void OnParticleCollision(GameObject other)
    {
		int numCollisionEvents = GetComponent<ParticleSystem>().GetCollisionEvents(other, collisionEvents);
		
		foreach (var item in collisionEvents)
		{
			if (!item.colliderComponent.GetComponent<PlayerController>())
       	 	{
           		return;
        	}
			if (item.colliderComponent.GetComponent<PlayerController>())
       	 	{
           		//item.colliderComponent.gameObject.GetComponent<PlayerStats>().DeductHp(4);
				GetComponent<DamageActor>().DealDamage(4, item.colliderComponent.gameObject, GetComponent<DamageActor>().damageType);
				Vector3 direction = item.colliderComponent.transform.position - transform.position;
            	direction = direction.normalized;
				item.colliderComponent.GetComponent<Rigidbody2D>().AddForce(transform.up * knockbackForce);
        	}
		}

    }
}
