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
	
	public UnityEvent TriggerChecks;
	public UnityEvent EventOnAllInteracted;
	public UnityEvent EventOnAllEnemiesDead;
	public UnityEvent EventOnAllItemsInInventory;
	public UnityEvent EventOnEnemiesInSpawnerDead;

	public List<Interactable> genericInteractable;
	public List<EnemyController> enemies;
	public List<BaseItem> itemsRequired;
	public Spawner spawner;

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
		if(genericInteractable.All(pad => pad.isInteracted == true)) 
		{
			areAllInteractablesInteracted = true;
			EventOnAllInteracted.Invoke();
			return;
		}
		areAllInteractablesInteracted = false;
	}

	public void checkEnemies()
	{
		if(enemies.All(enemies => enemies == null)) 
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
				areAllEnemiesDead = false;
				return;
			}
		}
		areAllEnemiesDead = true;
		EventOnAllItemsInInventory.Invoke();
	}

	public void checkSpawnerEnemies()
	{
		if(spawner == null) return;
		if(spawner.allSpawnedPrefabs.All(enemies => enemies.GetComponent<EnemyController>().gameObject == null) || (spawner.allSpawnedPrefabs.Count == 0)) 
		{
			areAllEnemiesInSpawnerDead = true;
			EventOnEnemiesInSpawnerDead.Invoke();
			return;
		}
		areAllEnemiesInSpawnerDead = false;
	}
}
