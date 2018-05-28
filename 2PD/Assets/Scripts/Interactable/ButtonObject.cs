using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ButtonObject : Interactable {
	public int playerIDRequired;
	public int buttonID;
	public bool isInteracted;

	public Sprite on;
	public Sprite off;

	public override void Start()
	{
		base.Start();
		gameManager.playerList.First(player => player.playerID == playerIDRequired).EventOnInteract.AddListener(Interact);
	}

	public override void Interact(PlayerController player)
	{
		if (player.playerID == playerIDRequired)
		{
			isInteracted = true;
			GetComponent<SpriteRenderer>().sprite = on;
			EventInteract.Invoke();
		}
	}


}
