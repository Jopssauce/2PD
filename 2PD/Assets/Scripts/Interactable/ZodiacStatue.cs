﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZodiacStatue : Interactable 
{
	public BaseItem itemRequired;
	public GameObject particle;
	bool isToggled;
	public string dialogue;
	public Sprite on;
	public Sprite off;
    bool canInput = true;
    void LateUpdate()
	{
		if(gameManager == null) gameManager = GameManager.instance;
	}
	public override void Interact(GameObject actor)
	{
		if(isInteracted || Time.timeScale == 0 || !canInput) return;
		gameManager.uiManager.CanvasUI.EventDialogueClosed.AddListener(gameManager.uiManager.CanvasUI.ForceOpen);
		GetComponent<InteractEventHandler>().ActivateDialogue(dialogue);
		gameManager.uiManager.CanvasUI.encyclopedia.GetComponent<InventoryActor>().interactable = this;
		EventInteracted.Invoke(actor);
	}
	public override void Activate(GameObject actor)
	{
		particle.SetActive(true);
		isInteracted = true;
		gameManager.uiManager.CanvasUI.OpenEnycloepdia();
		gameManager.uiManager.CanvasUI.EventDialogueClosed.RemoveListener(gameManager.uiManager.CanvasUI.ForceOpen);
		EventActivated.Invoke(actor);
	}
	public override void Deactivate(GameObject actor)
	{
		gameManager.uiManager.CanvasUI.encyclopedia.GetComponent<InventoryActor>().interactable = null;
		gameManager.uiManager.CanvasUI.EventDialogueClosed.RemoveListener(gameManager.uiManager.CanvasUI.ForceOpen);
		EventDeactivated.Invoke(actor);
	}


    IEnumerator Delay()
    {
        canInput = false;
        yield return new WaitForSecondsRealtime(0.5f);
        canInput = true;
    }



}
