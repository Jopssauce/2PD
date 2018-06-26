using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour 
{
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.B)) 
		{
			LoadScene ("Floor 1");
			UnloadScene ("Title Scene");
		}
	}

	public void LoadScene(string name)
	{
		FindObjectOfType<AudioManager> ().Play (MusicStrings.SoundFx_Select);
		SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
	}

	public void UnloadScene(string name)
	{
		FindObjectOfType<AudioManager> ().Play (MusicStrings.SoundFx_Select);
		SceneManager.UnloadSceneAsync (name);
	}

	// Only Works on build
	public void QuitApplication()
	{
		FindObjectOfType<AudioManager> ().Play (MusicStrings.SoundFx_Select);
		Application.Quit ();
	}
}
