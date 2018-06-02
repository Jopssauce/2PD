using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : Interactable {

	public override void Start () 
	{
		currentPlayer = null;
		isInteractable = false;
		isGrabbable = true;
		gameManager = GameManager.instance;
		foreach (var player in gameManager.playerList)
		{
			player.EventOnInteract.AddListener (Interact);
		}
	}
	
	public override void Interact(PlayerController player)
	{
		if (currentPlayer == player && isInteractable == true)
		{
			player.GetComponent<PlayerActions>().objectToActOn = this;
			player.GetComponent<PlayerActions>().canAction = true;
			player.GetComponent<PlayerActions>().Lift();
			Debug.Log("Interactable");
			EventInteract.Invoke();
		}
		
	}
}
