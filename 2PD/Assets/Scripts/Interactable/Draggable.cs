using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : Interactable {

	public override void Start () 
	{
		currentPlayer = null;
		isInteractable = false;
		isGrabbable = true;
		gameManager = GameManager.instance;
	}
	
	public override void Interact(PlayerController player)
	{
		if (player != null)
		{
			player.GetComponent<PlayerActions>().objectToActOn = this;
			player.GetComponent<PlayerActions>().canAction = true;
			player.GetComponent<PlayerActions>().Grab();
			Debug.Log("Interactable");
			EventInteract.Invoke();
		}
		
	}
}
