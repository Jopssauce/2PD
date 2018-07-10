using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AllahuAI : EnemyAI {
	GameManager gameManager;
	public float range = 5;
	public override void ChasePlayer ()
	{
        if (players.Count == 0) return;
        targetDirection = players[0].transform.position - enemyController.transform.position;
        targetDirection.Normalize();
		ResetDirection();
		enemyController.transform.position += targetDirection.normalized * moveSpeed * Time.deltaTime;
	}

	void LateUpdate()
	{
        float distance = 0;

        if (gameManager == null) gameManager = GameManager.instance;
        foreach (var item in gameManager.playerList)
        {
            distance = Vector2.Distance(transform.position, item.transform.position);
            if (distanceToTarget < range && players.Any(player => player.ID == item.gameObject.GetComponent<PlayerController>().ID) == false)
            {
                players.Add(item);
            }
            if (distance > range && players.Any(player => player.ID == item.gameObject.GetComponent<PlayerController>().ID) == true)
            {
                players.Remove(item);
            }
        }
        ChasePlayer();
    }

    public override void ResetDirection()
    {
        if (players.Count == 0) return;
        distanceToTarget = Vector2.Distance(players[0].transform.position, enemyController.transform.position);
        if (distanceToTarget < stopRange) targetDirection = Vector2.zero;
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
