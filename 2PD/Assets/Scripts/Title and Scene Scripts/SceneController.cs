using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneController : MonoBehaviour 
{
	public UnityEvent OnLoadScene;
	PersistentDataManager persistentData;

	void Start()
	{
		OnLoadScene.AddListener (PlaySound);
	}

	public void LateUpdate()
	{
		if(persistentData == null)persistentData = PersistentDataManager.instance;
	}


	public void LoadScene(string name)
	{
		if (!isSceneOpen (name))
		{
			OnLoadScene.Invoke ();
			SceneManager.LoadSceneAsync (name, LoadSceneMode.Additive);
		}
	}

	public void UnloadScene(string name)
	{
		SceneManager.UnloadSceneAsync (name);
	}

	public void Exit(string scene)
	{
		OnLoadScene.Invoke ();
		persistentData.StartChangeScene(scene);
	}

	// Only Works on build
	public void QuitApplication()
	{
		FindObjectOfType<AudioManager> ().Play (MusicStrings.SoundFx_Select);
		Application.Quit ();
	}

	bool isSceneOpen(string SceneName)
	{
		Scene AudioScene = SceneManager.GetSceneByName(SceneName);
		for (int i = 0; i < SceneManager.sceneCount; i++)
		{
			if (SceneManager.GetSceneAt(i) == AudioScene)
			{

				return true;
			}
		}
		return false;
	}

	void PlaySound()
	{
		FindObjectOfType<AudioManager> ().Play (MusicStrings.SoundFx_Select);
	}
}
