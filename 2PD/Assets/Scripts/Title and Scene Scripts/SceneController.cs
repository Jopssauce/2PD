using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneController : MonoBehaviour 
{
	public UnityEvent OnLoadScene;
	SceneLoader sceneLoader;

	void Start()
	{
		OnLoadScene.AddListener (PlaySound);
	}

	public void LateUpdate()
	{
		if(sceneLoader == null)sceneLoader = SceneLoader.instance;
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
		if(sceneLoader.isSceneOpen(scene)) return;
		OnLoadScene.Invoke ();
		sceneLoader.StartChangeScene(scene);
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
