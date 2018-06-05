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

	void Start()
	{
		EventInRange.AddListener(Exit);
	}

	void Exit()
	{
		if (players.Count == requiredPlayers)
		{
			SceneManager.LoadSceneAsync(scene);
			SceneManager.UnloadSceneAsync("UI Scene");
		}
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && players.Any(player => player.playerID == col.gameObject.GetComponent<PlayerController>().playerID) == false)
		{		
			players.Add(col.gameObject.GetComponent<PlayerController>());
			EventInRange.Invoke();

		}


	}
	public void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && players.Any(player => player.playerID == col.gameObject.GetComponent<PlayerController>().playerID))
		{
			players.Remove(col.gameObject.GetComponent<PlayerController>());
			EventOutRange.Invoke();

		}

	}
}
