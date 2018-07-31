using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class IntroManager : MonoBehaviour {
	public List<PlayerController> players;
	public GameObject grid;
	public SceneLoader sceneLoader;
	public IntroDialogue id;
	public UnityEvent OnStart;
	// Use this for initialization
	void Start () {
		id.EventDialogueEnded.AddListener(LoadGame);
		OnStart.Invoke ();
	}
	
	// Update is called once per frame
	void Update () {
		if(sceneLoader == null) sceneLoader = SceneLoader.instance;
		foreach (var player in players)
		{
			player.EventOnDown.Invoke();
			player.EventOnMove.Invoke();
		}
	}

	public void LoadGame()
	{
		if(SceneManager.GetActiveScene().name == "Floor 1") return;
		sceneLoader.StartChangeScene("Floor 1");
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
