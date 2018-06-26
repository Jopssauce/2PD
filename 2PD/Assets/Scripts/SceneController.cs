using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour 
{
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.B))
			FindObjectOfType<AudioManager> ().Play (MusicStrings.SoundFx_Select);
	}

	public void LoadScene(string name)
	{
		
	}
}
