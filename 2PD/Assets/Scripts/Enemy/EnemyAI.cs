using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour {

	public List<PlayerController> players;
	public EnemyController enemyController;
	public float moveSpeed;
	public float range = 0.8f;
	public Vector3 targetDirection;
	public float distanceToTarget;
	public float stopRange = 0.14f;
	protected GameManager gameManager;
	public UnityEvent EventInRange;
	public UnityEvent EventExitRange;
	bool isWandering;
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
		MoveToDirection();
	}

	public virtual void ChasePlayer ()
	{
		//transform.position = Vector2.MoveTowards (transform.position, players[0].transform.position, moveSpeed * Time.deltaTime);
		if (players.Count == 0) 
		{
			if(!isWandering)StartCoroutine(Wander());
			return;
		}
        targetDirection = players[0].transform.position - enemyController.transform.position;
	}

	public virtual IEnumerator Wander()
	{
		isWandering = true;
		while (players.Count == 0 && isWandering)
		{
			int rngX = Random.Range(-1, 2);
			int rngY = Random.Range(-1, 2);
			targetDirection.x = rngX;
			targetDirection.y = rngY;
			yield return new WaitForSeconds(Random.Range(0.5f, 0.7f));
			targetDirection = Vector2.zero;
			yield return new WaitForSeconds(Random.Range(1, 3));
		}
		ChasePlayer ();
		isWandering = false;
	}

	public void MoveToDirection()
	{
		if(targetDirection == Vector3.zero) return;
		targetDirection.Normalize();
		ResetDirection();
		enemyController.transform.position += targetDirection.normalized * moveSpeed * Time.deltaTime;
	}

	public virtual void ResetDirection()
	{
		if (players.Count == 0) return;
        distanceToTarget = Vector2.Distance(players[0].transform.position, enemyController.transform.position);
        if (distanceToTarget < stopRange) targetDirection = Vector2.zero;
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
	
}
