using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour 
{
	void Update()
	{
		if(Input.GetButtonDown("Vertical"))
			FindObjectOfType<AudioManager> ().Play (MusicStrings.SoundFx_Hover);
	}

	public void LoadScene(string name)
	{
		FindObjectOfType<AudioManager> ().Play (MusicStrings.SoundFx_Select);
	}
}
