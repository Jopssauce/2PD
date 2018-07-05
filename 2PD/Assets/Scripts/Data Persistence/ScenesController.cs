using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour {
	public static ScenesController instance;
	public void Awake()
	{
		instance = this;
		
	}

	
	bool isSceneOpen(string name)
	{
		Scene UIscene = SceneManager.GetSceneByName(name);
		for (int i = 0; i < SceneManager.sceneCount; i++)
		{
			if (SceneManager.GetSceneAt(i) == UIscene)
			{
				
				return true;
			}
		}
		return false;
	}

	public void LoadSceneWithUI(string name)
	{
		if(!isSceneOpen("UI Scene")) SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
		if(!isSceneOpen(name)) SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
		SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));
	}

	public void UnLoadScene(string name)
	{
		if(isSceneOpen(name)) SceneManager.UnloadSceneAsync(name);
	}

	public void LoadScene(string name)
	{
		if(!isSceneOpen(name)) SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
		SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));
	}

	void LoadTitleSceneOnStart()
	{
		if(!isSceneOpen("Title Scene") && !isSceneOpen("Floor 1") && !isSceneOpen("Floor 2"))
		{
			SceneManager.LoadSceneAsync("Title Scene", LoadSceneMode.Additive);
			SceneManager.SetActiveScene(SceneManager.GetSceneByName("Title Scene"));
		}
	}

	
}
