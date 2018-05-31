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
	

	public List<PlayerController> players;

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

		public override void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && players.Any(player => player.playerID == col.gameObject.GetComponent<PlayerController>().playerID) == false)
		{		
			col.gameObject.GetComponent<PlayerController>().EventOnInteract.AddListener(Interact);
			players.Add(col.gameObject.GetComponent<PlayerController>());
			EventInRange.Invoke();
			isInteractable = true;
		}
		
	}
	public override void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && players.Any(player => player.playerID == col.gameObject.GetComponent<PlayerController>().playerID))
		{
			players.Remove(col.gameObject.GetComponent<PlayerController>());
			col.gameObject.GetComponent<PlayerController>().EventOnInteract.RemoveListener(Interact);
			EventOutRange.Invoke();
			isInteractable = false;
		}
	}
	
}
