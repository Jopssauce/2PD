﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
	public static UIManager instance;
	[HideInInspector]
	public GameManager gameManager;
	public CanvasController CanvasUI;
	
	void Awake()
	{
		gameManager = GameManager.instance;
		instance = this;
	}

	public void ActivateDialogue(string dialogue)
	{
		CanvasUI.GetComponent<CanvasController>().DialogueCanvas(dialogue);
	}
	
}
