using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamage : MonoBehaviour {

	public List<GameObject> objects;
	public List<ParticleCollisionEvent> collisionEvents;

	void Start()
	{
		collisionEvents = new List<ParticleCollisionEvent>();
	}

	void OnParticleCollision(GameObject other)
    {
		int numCollisionEvents = GetComponent<ParticleSystem>().GetCollisionEvents(other, collisionEvents);
		
		foreach (var item in collisionEvents)
		{
			if (item.colliderComponent.gameObject.tag != "Player")
       	 	{
           		return;
        	}
			if (item.colliderComponent.gameObject.tag == "Player")
       	 	{
           		item.colliderComponent.gameObject.GetComponent<PlayerStats>().DeductHp(4);

				Vector3 direction = item.colliderComponent.transform.position - transform.position;
            	direction = direction.normalized;
				item.colliderComponent.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 5);
        	}
		}

    }
}
