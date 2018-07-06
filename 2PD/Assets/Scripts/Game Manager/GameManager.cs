using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public UIManager uiManager;
	public bool isRespawning = false;
	public List<PlayerController> playerList;
	public Inventory sharedInventory;
	public GameObject checkpoint;
	IEnumerator respawn;
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
		if(uiManager == null) uiManager = UIManager.instance;
		if (playerList.Any(player => player.GetComponent<Health>().health <= 0) && !isRespawning)
		{
			isRespawning = true;
			respawn = RespawnPlayers();
			StartCoroutine(respawn);
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



	public IEnumerator RespawnPlayers()
	{
		foreach (var player in playerList)
		{
			player.canMove = false;
			uiManager.CanvasUI.youDied.gameObject.SetActive(true);
		}
		yield return new WaitForSeconds(5);
		if (checkpoint == null)
		{
			SceneManager.LoadSceneAsync("Game Over Scene");
			SceneManager.UnloadSceneAsync("UI Scene");
		}
		foreach (var player in playerList)
		{
			player.GetComponent<Health>().AddHp(player.GetComponent<Health>().maxHealth);
			player.transform.position = checkpoint.transform.position;
			player.canMove = true;
		}
		isRespawning = false;
		uiManager.CanvasUI.youDied.gameObject.SetActive(false);
	}

	

	
}
