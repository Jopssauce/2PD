using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {

	Animator animator;

	public void Start()
	{
		animator = GetComponent<Animator>();
		SceneManager.sceneLoaded += OnSceneLoaded;
	}


	public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		Debug.Log("test");
		animator.SetTrigger ("Fade");
	}
}
