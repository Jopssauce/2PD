using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PressurePad : Interactable 
{
	public int playerIDRequired;
	public int buttonID;
	public bool isInteracted;

	public Sprite off;
	public Sprite on;
	
	public override void Start()
	{
		base.Start();
		EventInRange.AddListener(SetInteracted);
		//EventInRange.AddListener(OnSprite);
		EventOutRange.AddListener(SetInteracted);
		EventOutRange.AddListener(OffSprite);
		//gameManager.playerList.First(player => player.playerID == playerIDRequired).EventOnInteract.AddListener(Interact);
	}


	void SetInteracted()
	{
		if(players.Count == 0) return;
		if (players.Any(player => player.playerID == playerIDRequired) == true)
		{
			OnSprite();
			isInteracted = !isInteracted;
		}
	}

	void OnSprite()
	{
		GetComponent<SpriteRenderer>().sprite = on;
	}

	void OffSprite()
	{
		GetComponent<SpriteRenderer>().sprite = off;
	}


	
}
