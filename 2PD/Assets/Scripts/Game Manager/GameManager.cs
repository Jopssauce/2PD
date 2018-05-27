using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
			player.playerID = id;
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
		
	}

	bool isUIOpen()
	{
		Scene UIscene = SceneManager.GetSceneByBuildIndex(1);
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
