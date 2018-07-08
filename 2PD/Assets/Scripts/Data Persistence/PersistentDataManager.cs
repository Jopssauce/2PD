using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PersistentDataManager : MonoBehaviour {
	public static PersistentDataManager instance;
	public Inventory sharedInventory;
	string seenToActive;
	// Use this for initialization
	void Awake () {
		instance = this;
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartChangeScene(string scene)
	{
		AsyncOperation asnyc = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
			
		StartCoroutine(ChangeScene(asnyc, scene));
	}

	public IEnumerator ChangeScene(AsyncOperation asnyc, string scene)
	{
		seenToActive = scene;
		yield return asnyc.isDone;
		Debug.Log("Test");
		SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
		
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{
		if(!SceneManager.GetSceneByName(seenToActive).isLoaded) return;
		SceneManager.SetActiveScene(SceneManager.GetSceneByName(seenToActive));
	}
}
