using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Retry : MonoBehaviour {
	PersistentDataManager persistentData;
	public UnityEvent EventOnRetry;
	void Start () 
	{
		if(persistentData == null)
		{
			 persistentData = PersistentDataManager.instance;
		}

	}
	
	void LateUpdate () 
	{
		if(persistentData == null) persistentData = PersistentDataManager.instance;
	}

	public void RetryClick()
	{
		persistentData.StartChangeScene("Title Scene");
		EventOnRetry.Invoke();
	}
}
