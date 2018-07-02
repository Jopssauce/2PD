using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carryable : Interactable {
	// Use this for initialization
	
	public override void Start () 
	{
		currentPlayer = null;
		isInteractable = false;
		isCarryable = true;
		gameManager = GameManager.instance;
		foreach (var player in gameManager.playerList)
		{
			player.EventOnInteract.AddListener (Interact);
		}
	}
	
	public override void Interact(GameObject obj)
	{
		PlayerController player = obj.GetComponent<PlayerController>();
		if (currentPlayer == player && isInteractable == true)
		{
			player.GetComponent<PlayerActions>().objectToActOn = this;
			player.GetComponent<PlayerActions>().canAction = true;
			player.GetComponent<PlayerActions>().Lift();
			Debug.Log("Interactable");
			EventInteract.Invoke();
		}
		
	}

	public void EnableGravity()
	{
		gameObject.layer = 9;
		GetComponent<Rigidbody2D>().gravityScale = 1f;
		StartCoroutine(DisableGravity());
	}

	IEnumerator DisableGravity()
	{
		yield return new WaitForSeconds(0.1f);
		gameObject.layer = 0;
		GetComponent<Rigidbody2D>().gravityScale = 0.0f;
		GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		StopAllCoroutines();
	}

}
