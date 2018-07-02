using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class InteractableChecker : MonoBehaviour 
{
	GameManager gameManager;
	

	public bool areAllInteractablesInteracted;
	public bool areAllEnemiesDead;
	public bool areItemsInInventory;
	public bool areAllEnemiesInSpawnerDead;
	public Spawner spawner;
	public UnityEvent TriggerChecks;
	public UnityEvent EventOnAllInteracted;
	public UnityEvent EventOnAllEnemiesDead;
	public UnityEvent EventOnAllItemsInInventory;
	public UnityEvent EventOnEnemiesInSpawnerDead;

	public List<Interactable> genericInteractable;
	public List<EnemyController> enemies;
	public List<BaseItem> itemsRequired;
	

	void Start()
	{
		gameManager = GameManager.instance;
		TriggerChecks.AddListener(checkAllInteracted);
		TriggerChecks.AddListener(checkEnemies);
		TriggerChecks.AddListener(checkItems);
		TriggerChecks.AddListener(checkSpawnerEnemies);
	}

	public void InvokeCheck()
	{
		TriggerChecks.Invoke();
	}

	public void checkAllInteracted()
	{
		if(genericInteractable.All(pad => pad.isInteracted == true) || genericInteractable.Count == 0) 
		{
			areAllInteractablesInteracted = true;
			EventOnAllInteracted.Invoke();
			return;
		}
		areAllInteractablesInteracted = false;
	}

	public void checkEnemies()
	{
		if(enemies.All(enemies => enemies == null) || enemies.Count == 0) 
		{
			areAllEnemiesDead = true;
			EventOnAllEnemiesDead.Invoke();
			return;
		}
		areAllEnemiesDead = false;
	}

	public void checkItems()
	{
		foreach (var item in itemsRequired)
		{
			if(!gameManager.sharedInventory.itemInventory.Any(t => t.itemID == item.itemID)) 
			{
				areItemsInInventory = false;
				return;
			}
		}
		areItemsInInventory = true;
		EventOnAllItemsInInventory.Invoke();
	}

	public void checkSpawnerEnemies()
	{
		if(spawner == null) 
		{
			areAllEnemiesInSpawnerDead = true;
			return;
		}
		if(spawner.allSpawnedPrefabs.All(enemies => enemies == null) || spawner.allSpawnedPrefabs.Count == 1) 
		{		
			areAllEnemiesInSpawnerDead = true;
			EventOnEnemiesInSpawnerDead.Invoke();
			return;
		}
		areAllEnemiesInSpawnerDead = false;
	}
}
