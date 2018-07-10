using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour {

	public List<PlayerController> players;
	public EnemyController enemyController;
	public float moveSpeed;
	public Vector3 targetDirection;
	public float distanceToTarget;
	public float stopRange = 0.14f;

	public UnityEvent EventInRange;
	public UnityEvent EventExitRange;

	void LateUpdate()
	{
		if(players.Count == 0)
		{
			//StartCoroutine(Wander());
			return;
		}
		else
		{
			StopCoroutine(Wander());
			ChasePlayer ();
		} 
		
	}

	public virtual void ChasePlayer ()
	{
		//transform.position = Vector2.MoveTowards (transform.position, players[0].transform.position, moveSpeed * Time.deltaTime);
		targetDirection = players[0].transform.position - enemyController.transform.position;
		ResetDirection();
		transform.position += targetDirection * moveSpeed * Time.deltaTime;
		enemyController.transform.position += targetDirection * moveSpeed * Time.deltaTime;
	}

	public virtual IEnumerator Wander()
	{
		while (players.Count == 0)
		{
			int rngX = Random.Range(-1, 2);
			int rngY = Random.Range(-1, 2);
			targetDirection.x = rngX;
			targetDirection.y = rngY;
			yield return new WaitForSeconds(Random.Range(1, 3));
		}
		
	}

	public virtual void ResetDirection()
	{
		distanceToTarget = Vector2.Distance(players[0].transform.position, enemyController.transform.position);
		if(distanceToTarget < stopRange) targetDirection = Vector2.zero;
	}


	public virtual void OnTriggerEnter2D(Collider2D col)
	{
		if(!col.gameObject.CompareTag("Player")) return;
		if (col.gameObject.tag == "Player" && players.Any(player => player.ID == col.gameObject.GetComponent<PlayerController>().ID) == false)
		{		
			players.Add(col.gameObject.GetComponent<PlayerController>());
			EventInRange.Invoke();
		}
		
	}
	public virtual void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && players.Any(player => player.ID == col.gameObject.GetComponent<PlayerController>().ID))
		{
			players.Remove(col.gameObject.GetComponent<PlayerController>());
			EventExitRange.Invoke();
			
			this.gameObject.transform.localPosition = new Vector2(0,0);
		}
	}
}
