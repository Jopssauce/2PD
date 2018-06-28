using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class InteractableChecker : MonoBehaviour 
{
	GameManager gameManager;
	

	public bool areAllInteracted;
	public bool areAllEnemiesDead;
	public bool areItemsInInventory;
	
	public UnityEvent TriggerChecks;
	public UnityEvent EventOnAllInteracted;
	public UnityEvent EventOnAllEnemiesDead;
	public UnityEvent EventOnAllItemsInInventory;

	public List<Interactable> genericInteractable;
	public List<EnemyController> enemies;
	public List<BaseItem> itemsRequired;

	void Start()
	{
		gameManager = GameManager.instance;
		TriggerChecks.AddListener(checkAllInteracted);
		TriggerChecks.AddListener(checkEnemies);
		TriggerChecks.AddListener(checkItems);
	}

	public void checkAllInteracted()
	{
		if(genericInteractable.All(pad => pad.isInteracted == true)) 
		{
			areAllInteracted = true;
			EventOnAllInteracted.Invoke();
		}
		areAllInteracted = false;
	}

	public void checkEnemies()
	{
		if(enemies.All(enemies => enemies == null)) 
		{
			areAllEnemiesDead = true;
			EventOnAllEnemiesDead.Invoke();
		}
		areAllEnemiesDead = false;
	}

	public void checkItems()
	{
		foreach (var item in itemsRequired)
		{
			if(!gameManager.sharedInventory.itemInventory.Any(t => t.itemID == item.itemID)) 
			{
				areAllEnemiesDead = false;
				return;
			}
		}
		areAllEnemiesDead = true;
		EventOnAllItemsInInventory.Invoke();
	}
}
