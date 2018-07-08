using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEventHandler : MonoBehaviour {

	private AudioManager audioManager;
	// Use this for initialization
	void Start () 
	{
		audioManager = FindObjectOfType<AudioManager> ();
	}

	public void PlaySFX(string name)
	{
		if(audioManager != null)
			audioManager.Play (name);
	}

	public void PlayBGM(string name)
	{
		if (audioManager != null)
			audioManager.PlayMusic (name);
	}

	public void StopBGM(string name)
	{
		if (audioManager != null)
			audioManager.StopMusic (name);
	}
}
