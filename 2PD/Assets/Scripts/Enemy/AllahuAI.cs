using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllahuAI : EnemyAI {

	public override void ChasePlayer ()
	{
		//transform.position = Vector2.MoveTowards (transform.position, players[0].transform.position, moveSpeed * Time.deltaTime);
		targetDirection = players[0].transform.position - enemyController.transform.position;
		ResetDirection();
		//transform.position += targetDirection * moveSpeed * Time.deltaTime;
		enemyController.transform.position += targetDirection * moveSpeed * Time.deltaTime;
	}

}
