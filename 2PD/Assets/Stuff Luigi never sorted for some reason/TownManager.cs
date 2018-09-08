using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour {

	[HideInInspector]
	public UIManager uiManager;
	public static TownManager instance;

	// Use this for initialization
	void Awake () 
	{
		uiManager = UIManager.instance;
		instance = this;
	}
}
