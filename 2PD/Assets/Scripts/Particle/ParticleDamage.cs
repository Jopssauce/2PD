using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamage : MonoBehaviour {

	 void OnParticleCollision(GameObject other)
    {
        Rigidbody2D body = other.GetComponent<Rigidbody2D>();
		PlayerController player = other.GetComponent<PlayerController>();
        if (body)
        {
            Vector3 direction = other.transform.position - transform.position;
            direction = direction.normalized;
            body.AddForce(Vector3.up * 5);
        }
		if (player)
        {
           player.GetComponent<PlayerStats>().DeductHp(4);
        }
    }
}
