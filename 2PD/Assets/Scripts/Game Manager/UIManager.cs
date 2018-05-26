﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
	public static UIManager instance;
	public GameManager gameManager;
	
	void Awake()
	{
		gameManager = GameManager.instance;
		instance = this;
	}
	
}