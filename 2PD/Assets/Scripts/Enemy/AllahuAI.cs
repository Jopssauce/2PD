using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllahuAI : EnemyAI {
	GameManager gameManager;
	public float range = 5;
	public override void ChasePlayer ()
	{
		//transform.position = Vector2.MoveTowards (transform.position, players[0].transform.position, moveSpeed * Time.deltaTime);
		//targetDirection = players[0].transform.position - enemyController.transform.position;
		//ResetDirection();
		//transform.position += targetDirection * moveSpeed * Time.deltaTime;
		//enemyController.transform.position += targetDirection.normalized * moveSpeed * Time.deltaTime;
	}

	void LateUpdate()
	{
		if(gameManager == null) gameManager = GameManager.instance;
		enemyController.transform.position += targetDirection.normalized * moveSpeed * Time.deltaTime;

		foreach (var item in gameManager.playerList)
		{
			if(Vector2.Distance(transform.position, item.transform.position) < range) targetDirection = item.transform.position - enemyController.transform.position;
			targetDirection.Normalize();
		}
	}

	public override void OnTriggerEnter2D(Collider2D col)
	{

	}
	public override void OnTriggerExit2D(Collider2D col)
	{

	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}

}
