using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEventHandler : MonoBehaviour {

	public void PlaySFX(string name)
	{
		if(FindObjectOfType<AudioManager> () != null)
			FindObjectOfType<AudioManager> ().Play (name);
	}

	public void PlayBGM(string name)
	{
		if (FindObjectOfType<AudioManager> () != null)
			FindObjectOfType<AudioManager> ().PlayMusic (name);
		else
			Debug.Log ("null");
	}

	public void StopBGM(string name)
	{
		if (FindObjectOfType<AudioManager> () != null)
			FindObjectOfType<AudioManager> ().StopMusic (name);
	}
}
