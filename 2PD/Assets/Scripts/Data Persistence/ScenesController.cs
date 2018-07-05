using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour {

	public Scene titleScene;
	public void Awake()
	{
		if(!isSceneOpen("Title Scene")) SceneManager.LoadSceneAsync("Title Scene", LoadSceneMode.Additive);
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

	
}
