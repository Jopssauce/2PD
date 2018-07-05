using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public List<PlayerController> playerList;
	public Inventory sharedInventory;
	void Awake()
	{
		instance = this;
		int id = 0;
		foreach (var player in playerList)
		{
			player.ID = id;
			id++;
		}
		if(!isUIOpen()) SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	void LateUpdate () 
	{
		if (playerList.Any(player => player.GetComponent<Health>().health <= 0))
		{
			SceneManager.LoadSceneAsync("Game Over Scene");
			SceneManager.UnloadSceneAsync("UI Scene");
		}
		if (Input.GetKeyDown(KeyCode.F5))
		{
			SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
		}
	}

	bool isUIOpen()
	{
		Scene UIscene = SceneManager.GetSceneByName("UI Scene");
		for (int i = 0; i < SceneManager.sceneCount; i++)
		{
			if (SceneManager.GetSceneAt(i) == UIscene)
			{
				
				return true;
			}
		}
		return false;
	}

	
}
