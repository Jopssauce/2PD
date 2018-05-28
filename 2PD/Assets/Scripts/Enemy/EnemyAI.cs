using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour {

	public List<PlayerController> players;
	public float moveSpeed;
	public Vector3 targetDirection;
	public float distanceToTarget;

	public UnityEvent EventInRange;
	public UnityEvent EventExitRange;

	void FixedUpdate()
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
		targetDirection = players[0].transform.position - this.transform.position;
		ResetDirection();
		transform.position += targetDirection * moveSpeed * Time.deltaTime;
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

	public void ResetDirection()
	{
		distanceToTarget = Vector2.Distance(players[0].transform.position, this.transform.position);
		if(distanceToTarget <= 0.2f) targetDirection = Vector2.zero;
	}


	public virtual void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && players.Any(player => player.playerID == col.gameObject.GetComponent<PlayerController>().playerID) == false)
		{		
			players.Add(col.gameObject.GetComponent<PlayerController>());
			EventInRange.Invoke();
		}
		
	}
	public virtual void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && players.Any(player => player.playerID == col.gameObject.GetComponent<PlayerController>().playerID))
		{
			players.Remove(col.gameObject.GetComponent<PlayerController>());
			EventExitRange.Invoke();
		}
	}
}
