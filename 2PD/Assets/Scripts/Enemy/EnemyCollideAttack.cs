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
			if(enemyAI.players[0] == null) return;		
			StartCoroutine(Attack());
		}
		
	}
	public virtual void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			StopCoroutine(Attack());
		}
	}

	public IEnumerator Attack()
	{
		while (enemyAI.players[0] != null)
		{
			enemyAI.players[0].GetComponent<PlayerStats>().DeductHp(damage);
			yield return new WaitForSeconds(attackTimer);
		}
		
	}

}
