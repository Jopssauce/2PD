using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	ScenesController scenesController;
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
	}

	// Use this for initialization
	void Start () 
	{
		scenesController = ScenesController.instance;
		scenesController.LoadScene("UI Scene");
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

	bool isScenesControllerOpen()
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
