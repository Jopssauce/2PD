using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable {
	public int playerIDRequired;
	public int buttonID;
	public bool isInteracted;
	public override void Interact(PlayerController player)
	{
		if (player.playerID == playerIDRequired)
		{
			isInteracted = true;
			EventInteract.Invoke();
		}
	}


}
