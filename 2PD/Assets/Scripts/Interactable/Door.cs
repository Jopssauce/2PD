using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Door : Interactable 
{
	public bool isOpen;
	public List<Button> buttons;
	public List<PlayerController> players;
	
	public override void Interact(PlayerController player)
	{
		if (buttons.All(button => button.isInteracted = true))
		{
			EventInteract.Invoke();
		}
	}

	public override void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player" && players.Any(player => player.playerID != col.gameObject.GetComponent<PlayerController>().playerID))
		{		
			currentPlayer = col.gameObject.GetComponent<PlayerController>();
			players.Add(currentPlayer);
			EventInRange.Invoke();
			isInteractable = true;
		}
		
	}
	public override void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player" && players.Any(player => player.playerID == col.gameObject.GetComponent<PlayerController>().playerID))
		{
			players.Remove(col.gameObject.GetComponent<PlayerController>());
			EventOutRange.Invoke();
			isInteractable = false;
		}
	}


}
