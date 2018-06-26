using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour 
{
	public void LoadScene(string name)
	{
		FindObjectOfType<AudioManager> ().Play (MusicStrings.SoundFx_Select);
		SceneManager.LoadSceneAsync(name);
	}

	// Only Works on build
	public void QuitApplication()
	{
		FindObjectOfType<AudioManager> ().Play (MusicStrings.SoundFx_Select);
		Application.Quit ();
	}
}
