using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
[System.Serializable]
public class SceneEvents : UnityEvent<Scene>{}
public class PersistentDataManager : MonoBehaviour {
	public static PersistentDataManager instance;
	public Canvas loadingScreen;
	public Inventory sharedInventory;
	string seenToActive;
	public SceneEvents EventSceneLoaded;
	public AsyncOperation sceneAsync;
	// Use this for initialization
	void Awake () {
		instance = this;
		SceneManager.sceneLoaded += OnSceneLoaded;
		SceneManager.sceneLoaded += ReturnLoadedScene;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F5))
		{
			SceneManager.UnloadSceneAsync("UI Scene");
			StartChangeScene("Floor 1");
		}
		if(Input.GetKeyDown(KeyCode.F6))
		{
			SceneManager.UnloadSceneAsync("UI Scene");
			StartChangeScene("Floor 2");
		} 
	}

	public void StartChangeScene(string scene)
	{
		AsyncOperation asnyc = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
		sceneAsync = asnyc;
		StartCoroutine(ChangeScene(asnyc, scene));
	}

	public bool isSceneOpen(string SceneName)
	{
		Scene scene = SceneManager.GetSceneByName(SceneName);
		for (int i = 0; i < SceneManager.sceneCount; i++)
		{
			if (SceneManager.GetSceneAt(i) == scene)
			{

				return true;
			}
		}
		return false;
	}

	public IEnumerator ChangeScene(AsyncOperation asnyc, string scene)
	{
		seenToActive = scene;
		loadingScreen.gameObject.SetActive(true);
		yield return asnyc.isDone;
		Debug.Log("Test");
		SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
		
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{
		if(!SceneManager.GetSceneByName(seenToActive).isLoaded) return;
		SceneManager.SetActiveScene(SceneManager.GetSceneByName(seenToActive));
		loadingScreen.gameObject.SetActive(false);
		
	}

	void ReturnLoadedScene(Scene scene, LoadSceneMode loadSceneMode)
	{
		EventSceneLoaded.Invoke(scene);
	}
}
