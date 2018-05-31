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
		EventInRange.AddListener(OnSprite);
		EventOutRange.AddListener(SetInteracted);
		EventOutRange.AddListener(OffSprite);
		//gameManager.playerList.First(player => player.playerID == playerIDRequired).EventOnInteract.AddListener(Interact);
	}


	void SetInteracted(GameObject player)
	{
		if (player.GetComponent<PlayerController>().playerID == playerIDRequired)
		{
			isInteracted = !isInteracted;
		}
	}

	void OnSprite(GameObject player)
	{
		GetComponent<SpriteRenderer>().sprite = on;
	}

	void OffSprite(GameObject player)
	{
		GetComponent<SpriteRenderer>().sprite = off;
	}
	
}
