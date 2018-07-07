using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Door : Interactable 
{
	public bool isOpen;
	public bool autoOpen = true;
	public bool autoClose;
	public bool openImmediatelyWithoutTrigger;
	public GameObject targetLocation;
	public UnityEvent EventOnOpen;
	public UnityEvent EventOnClose;
	public Collider2D doorCol;
	public override void Start()
	{
		base.Start();
	}
	public override void Interact(GameObject actor)
	{
		if (players.Count == requiredPlayers && !autoOpen && playerCanTrigger) 
		{	
			OpenDoor();
			EventInteract.Invoke();
			if(isOpen == false) return;
		}
	}

	public override void Activate(GameObject actor)
	{
		OpenDoor();
		EventActivated.Invoke(actor);
	}

	public override void Deactivate(GameObject actor)
	{
		CloseDoor();
		EventDeactivated.Invoke(actor);
	}

	void LateUpdate()
	{
		if (autoOpen == true)
		{
			checker.TriggerChecks.Invoke();
			if (players.Count == requiredPlayers && checker.areAllEnemiesInSpawnerDead && checker.areAllInteractablesInteracted && checker.areItemsInInventory) 
			{
				isOpen = true;
				OpenDoor ();
			}
			else
			{
				if(autoClose)
				{
					isOpen = false;
					CloseDoor();
				}
				
			}
		}
		if(openImmediatelyWithoutTrigger == true)
		{
			if (checker.areAllEnemiesInSpawnerDead && checker.areAllInteractablesInteracted && checker.areItemsInInventory) 
			{
				isOpen = true;
				OpenDoor ();
			}
			else
			{
				if(autoClose)
				{
					isOpen = false;
					CloseDoor();
				}
			}
		}

		
	}


	void SetPlayersLocation(Vector3 targetLocation)
	{
		foreach (var item in players)
		{
			item.transform.position = targetLocation;
		}
	}

	public void OpenDoor()
	{
		doorCol.enabled = false;
		EventOnOpen.Invoke();
		isOpen = true;
	}
	public void CloseDoor()
	{
		doorCol.enabled = true;
		EventOnClose.Invoke();
		isOpen = false;
	}

	



}
