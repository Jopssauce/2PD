using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllahuCollideAttack : EnemyCollideAttack {
	public GameObject explosionPrefab;

	public override void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{	
			if(enemyAI.players.Count > 0) 
			{
				Instantiate (explosionPrefab, transform.position, explosionPrefab.transform.rotation);
				Destroy (this.gameObject);
			}		

		}

	}
	public virtual void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			
		}
	}

}
