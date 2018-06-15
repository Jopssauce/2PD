using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Door : Interactable 
{
	public bool isOpen;
	public bool autoOpen = true;
	public int requiredPlayers;
	public List<Switch> switches;
	public List<EnemyController> enemies;
	public BaseItem keyRequired;
	public GameObject targetLocation;
	public UnityEvent EventOnOpen;
	public UnityEvent EventOnClose;
	public Collider2D doorCol;
	public override void Start()
	{
		base.Start();
		//requiredPlayers = gameManager.playerList.Capacity;
	}
	public override void Interact(PlayerController player)
	{
		if (switches.All(button => button.isInteracted))
		{	
			OpenDoor();
			EventInteract.Invoke();
			if(isOpen == false) return;
			//SetPlayersLocation(targetLocation.transform.position);
		}
	}

	void LateUpdate()
	{
		if (autoOpen == true)
		{
			OpenDoor();
		}
		else
		{
			CloseDoor();
		}
	}


	void SetPlayersLocation(Vector3 targetLocation)
	{
		foreach (var item in players)
		{
			item.transform.position = targetLocation;
		}
	}

	void OpenDoor()
	{
		if (players.Count == requiredPlayers && enemies.All(enemies => enemies == null) && SearchForKey() == true && switches.All(button => button.isInteracted))
		{
			Debug.Log(players.Count + " " + requiredPlayers);
			doorCol.enabled = false;
			EventOnOpen.Invoke();
			isOpen = true;
		}
	}
	void CloseDoor()
	{
			doorCol.enabled = true;
			EventOnClose.Invoke();
			isOpen = false;
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
