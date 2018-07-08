using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour {

	[SerializeField]
	private Button StartButton;

	[SerializeField]
	private Button ExitButton;

	private float Timer = 13.0f;

	void Awake()
	{
		if(!isAudioOpen())
			SceneManager.LoadSceneAsync("Audio", LoadSceneMode.Additive);
		
	}

	void Start()
	{
		FindObjectOfType<AudioManager> ().PlayMusic (MusicStrings.Music_Title);
	}

	bool isAudioOpen()
	{
		Scene AudioScene = SceneManager.GetSceneByName("Audio");
		for (int i = 0; i < SceneManager.sceneCount; i++)
		{
			if (SceneManager.GetSceneAt(i) == AudioScene)
			{

				return true;
			}
		}
		return false;
	}

	void Update()
	{
		Timer -= Time.deltaTime;
		ButtonHandler ();
	}

	void ButtonHandler()
	{
		if (Timer <= 0.0f) 
		{
			StartButton.gameObject.SetActive (true);
			ExitButton.gameObject.SetActive (true);
		}
	}

	public void SelectSound()
	{
		FindObjectOfType<AudioManager> ().Play (MusicStrings.SoundFx_Select);
	}
}
