using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
[System.Serializable]
public class SceneEvents : UnityEvent<Scene>{}
public class PersistentDataManager : MonoBehaviour {
	public static PersistentDataManager instance;
	public Inventory sharedInventory;
	string seenToActive;
	public SceneEvents EventSceneLoaded;
	// Use this for initialization
	void Awake () {
		instance = this;
		SceneManager.sceneLoaded += OnSceneLoaded;
		SceneManager.sceneLoaded += ReturnLoadedScene;
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

	void ReturnLoadedScene(Scene scene, LoadSceneMode loadSceneMode)
	{
		EventSceneLoaded.Invoke(scene);
	}
}
