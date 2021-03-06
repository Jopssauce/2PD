﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PressurePad : Interactable 
{
	public int playerIDRequired;
	public Interactable objectRequired;
	public Sprite off;
	public Sprite on;
	
	public override void Start()
	{
		base.Start();
		EventInRange.AddListener(Interact);
		EventOutRange.AddListener(Interact);
	}

	void LateUpdate()
	{
		if (players.Any(player => player.ID == playerIDRequired) || players.Count > 0 && playerCanTrigger || allObjects.Any(item => item.gemType == objectRequired.gemType
		|| allObjects.Any(obj => obj.id == objectRequired.id)) )
		{
			OnSprite();
			isInteracted = true;
		}
		else
		{
			OffSprite();
			isInteracted = false;
		}
		
	}
	
	public override void Interact(GameObject actor)
	{
		if (players.Any(player => player.ID == playerIDRequired) || players.Count > 0 && playerCanTrigger )
		{
			OnSprite();
			isInteracted = !isInteracted;
			EventInteracted.Invoke(actor);
			EventActivated.Invoke(actor);
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
