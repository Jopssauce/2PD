using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyCollideAttack : MonoBehaviour {
	public float attackTimer;
	public float damage;
	public EnemyAI enemyAI;


	public virtual void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{	
			if(enemyAI.players.Count > 0) 
			{
				StartCoroutine(Attack());
			}		
			
		}
		
	}
	public virtual void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			StopAllCoroutines();
		}
	}

	public IEnumerator Attack()
	{
		while (enemyAI.players.Count > 0)
		{
			//enemyAI.players[0].GetComponent<PlayerStats>().DeductHp(damage);
			GetComponent<DamageActor>().DealDamage(damage, enemyAI.players[0].gameObject, GetComponent<DamageActor>().damageType);
			yield return new WaitForSeconds(attackTimer);
		}
		
	}

}
