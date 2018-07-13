using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TitleManager : MonoBehaviour {

	[SerializeField]
	private Button StartButton;

	[SerializeField]
	private Button ExitButton;

	[SerializeField]
	private EventSystem titleEventSystem;

	[SerializeField]
	private GameObject firstSelectStart;

	private float Timer = 13.0f;
	private bool IsDone = false;

	void Awake()
	{
		if(!isPersistentOpen())
			SceneManager.LoadSceneAsync("Persistent Scene", LoadSceneMode.Additive);
	}

	void Start()
	{
		FindObjectOfType<AudioManager> ().PlayMusic (MusicStrings.Music_Title);
	}

	bool isPersistentOpen()
	{
		Scene AudioScene = SceneManager.GetSceneByName("Persistent Scene");
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

			if (!IsDone) 
			{
				IsDone = true;
				titleEventSystem.SetSelectedGameObject (firstSelectStart);
			}
		}
	}

	public void SelectSound()
	{
		FindObjectOfType<AudioManager> ().Play (MusicStrings.SoundFx_Select);
	}
}
