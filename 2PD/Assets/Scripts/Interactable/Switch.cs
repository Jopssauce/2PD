using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Switch : Interactable {
	public int playerIDRequired;
	public int buttonID;

	public Sprite off;
	public Sprite on;
	
	public override void Start()
	{
		base.Start();
		//gameManager.playerList.First(player => player.playerID == playerIDRequired).EventOnInteract.AddListener(Interact);
	}

	public override void Interact(GameObject obj)
	{
		PlayerController player = obj.GetComponent<PlayerController>();
		if (player.ID == playerIDRequired || playerIDRequired == -1)
		{
			isInteracted = true;
			if(GetComponent<SpriteRenderer>())GetComponent<SpriteRenderer>().sprite = on;
			EventInteracted.Invoke(obj);
		}
	}

	

}
