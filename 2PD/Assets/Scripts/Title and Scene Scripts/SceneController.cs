using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneController : MonoBehaviour 
{
	public UnityEvent OnLoadScene;

	void Start()
	{
		OnLoadScene.AddListener (PlaySound);
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
