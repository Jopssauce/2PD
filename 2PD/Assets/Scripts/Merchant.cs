using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour {

	private GameManager gameManager;
	void Start () 
	{
		if (GameManager.instance != null)
			gameManager = GameManager.instance;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
