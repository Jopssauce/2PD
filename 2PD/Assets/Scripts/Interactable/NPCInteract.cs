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

	public override void Interact(PlayerController player)
	{
		EventInteract.Invoke();
		uiManager.CanvasUI.GetComponent<CanvasController> ().ActivateUIMerchant ();
		Debug.Log ("Merchant");
	}
}
