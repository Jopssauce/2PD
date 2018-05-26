using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Door : Interactable 
{
	public bool isOpen;
	public int requiredPlayers = 2;
	public List<ButtonObject> buttons;
	public List<PlayerController> players;
	public List<EnemyController> enemies;
	public GameObject targetLocation;
	public override void Start()
	{
		base.Start();
		foreach (var item in gameManager.playerList)
		{
			item.EventOnInteract.AddListener(Interact);
		}
		requiredPlayers = gameManager.playerList.Capacity;
	}
	public override void Interact(PlayerController player)
	{
		if (buttons.All(button => button.isInteracted == true))
		{	
			OpenDoor();
			EventInteract.Invoke();
			if(isOpen == false) return;
			SetPlayersLocation(targetLocation.transform.position);
		}
	}

	public override void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player" && players.Any(player => player.playerID == col.gameObject.GetComponent<PlayerController>().playerID) == false)
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

	void SetPlayersLocation(Vector3 targetLocation)
	{
		if(targetLocation == null) return;
		foreach (var item in players)
		{
			item.transform.position = targetLocation;
		}
	}

	void OpenDoor()
	{
		if (players.Count == requiredPlayers && enemies.All(enemies => enemies == null))
		{
			isOpen = true;
		}
	}


}
