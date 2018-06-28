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
		StartButton.interactable = false;
		Debug.Log (StartButton.IsInteractable());
		ExitButton.interactable = false;
		Debug.Log (ExitButton.IsInteractable());
		
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
		if (Timer <= 0.0f && !StartButton.IsInteractable() && !ExitButton.IsInteractable()) 
		{
			StartButton.interactable = true;
			ExitButton.interactable = true;
		}
	}

	public void SelectSound()
	{
		FindObjectOfType<AudioManager> ().Play (MusicStrings.SoundFx_Select);
	}
}
