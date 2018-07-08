using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using UnityEngine.SceneManagement;

public class ExitFloor : MonoBehaviour {
	public int requiredPlayers;
	public List<PlayerController> players;
	public UnityEvent EventInRange;
	public UnityEvent EventOutRange;
	public string scene;
	GameManager gameManager;

	void Start()
	{
		EventInRange.AddListener(Exit);
		gameManager = GameManager.instance;
	}

	void Exit()
	{
		if (players.Count == requiredPlayers)
		{
			
			foreach (var item in gameManager.sharedInventory.itemInventory)
			{
				if(item==null) continue;
				gameManager.persistentData.sharedInventory.AddItem(item); 
			}
			SceneManager.UnloadSceneAsync("UI Scene");
			gameManager.persistentData.StartChangeScene(scene);
			
			
		}
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && players.Any(player => player.ID == col.gameObject.GetComponent<PlayerController>().ID) == false)
		{		
			players.Add(col.gameObject.GetComponent<PlayerController>());
			EventInRange.Invoke();

		}


	}
	public void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && players.Any(player => player.ID == col.gameObject.GetComponent<PlayerController>().ID))
		{
			players.Remove(col.gameObject.GetComponent<PlayerController>());
			EventOutRange.Invoke();

		}

	}
}
