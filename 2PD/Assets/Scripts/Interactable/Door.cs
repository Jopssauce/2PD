using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Door : Interactable 
{
	public bool isOpen;
	public int requiredPlayers = 2;
	public List<Switch> switches;
	public List<EnemyController> enemies;
	public BaseItem keyRequired;
	public GameObject targetLocation;
	public override void Start()
	{
		base.Start();
		foreach (var item in gameManager.playerList)
		{
			//item.EventOnInteract.AddListener(Interact);
		}
		requiredPlayers = gameManager.playerList.Capacity;
	}
	public override void Interact(PlayerController player)
	{
		if (switches.All(button => button.isInteracted == true))
		{	
			OpenDoor();
			EventInteract.Invoke();
			if(isOpen == false) return;
			SetPlayersLocation(targetLocation.transform.position);
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
		if (players.Count == requiredPlayers && enemies.All(enemies => enemies == null) && SearchForKey() == true )
		{
			isOpen = true;
		}
	}

	bool SearchForKey()
	{
		if(keyRequired == null) return true;
		foreach (var item in gameManager.sharedInventory.itemInventory)
		{
			if (item.itemName == keyRequired.itemName)
			{
				return true;
			}
		}
		return false;
	}





}
