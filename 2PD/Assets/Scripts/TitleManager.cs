using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {



	void Awake()
	{
		if(!isAudioOpen())
			SceneManager.LoadSceneAsync("Audio", LoadSceneMode.Additive);
	}

	bool isAudioOpen()
	{
		Scene AudioScene = SceneManager.GetSceneByName("Audio");
		for (int i = 0; i < SceneManager.sceneCount; i++)
		{
			if (SceneManager.GetSceneAt(i) == AudioScene)
			{

				return true;
			}
		}
		return false;
	}
}
