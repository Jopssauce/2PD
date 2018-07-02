using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : Interactable {


	// Use this for initialization
	UIManager uiManager;
	public override void Start ()
	{
		base.Start ();
		if (UIManager.instance != null)
		{
			uiManager = UIManager.instance;
		}
	}

	public override void Interact(GameObject obj)
	{
		EventInteract.Invoke();
		Debug.Log ("Merchant");
	}
}
