using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawn : MonoBehaviour 
{
	public GameObject ChestToSpawn;
	private InteractableChecker checker;

	void Start()
	{
		checker = GetComponent<InteractableChecker> ();
	}

	void LateUpdate()
	{
		if (checker.areAllEnemiesDead) 
		{
			ChestToSpawn.SetActive (true);
		} 
		else 
		{
			ChestToSpawn.SetActive (false);
		}

		if (checker.areAllEnemiesInSpawnerDead)
		{
			ChestToSpawn.SetActive (true);
		}

		else
		{
			ChestToSpawn.SetActive (false);
		}
	}
}
