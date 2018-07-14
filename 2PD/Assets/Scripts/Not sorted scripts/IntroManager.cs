using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {
	public List<PlayerController> players;
	public GameObject grid;
	public PersistentDataManager pDataManager;
	public IntroDialogue id;
	// Use this for initialization
	void Start () {
		id.EventDialogueEnded.AddListener(LoadGame);
	}
	
	// Update is called once per frame
	void Update () {
		if(pDataManager == null) pDataManager = PersistentDataManager.instance;
		foreach (var player in players)
		{
			player.EventOnDown.Invoke();
			player.EventOnMove.Invoke();
		}
	}

	public void LoadGame()
	{
		if(SceneManager.GetActiveScene().name == "Floor 1") return;
		pDataManager.StartChangeScene("Floor 1");
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if(col.GetComponent<PlayerController>())
		{
			 grid.transform.position = this.transform.position; 
			 this.transform.position += -Vector3.up * 2f;
		}
	}
}
