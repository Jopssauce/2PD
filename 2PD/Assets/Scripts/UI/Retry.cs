using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Retry : MonoBehaviour {
	SceneLoader sceneLoader;
	public UnityEvent EventOnRetry;
	void Start () 
	{
		if(sceneLoader == null)
		{
			 sceneLoader = SceneLoader.instance;
		}

	}
	
	void LateUpdate () 
	{
		if(sceneLoader == null) sceneLoader = SceneLoader.instance;
	}

	public void RetryClick()
	{
		if(sceneLoader.isSceneOpen("Title scene")) return;
		sceneLoader.StartChangeScene("Title Scene");
		EventOnRetry.Invoke();
	}
}
