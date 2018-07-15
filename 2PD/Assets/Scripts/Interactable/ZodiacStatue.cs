using System.Collections;
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
	void LateUpdate()
	{
		if(gameManager == null) gameManager = GameManager.instance;
	}
	public override void Interact(GameObject actor)
	{
		if(isInteracted || Time.timeScale == 0) return;
		gameManager.uiManager.CanvasUI.EventDialogueClosed.AddListener(gameManager.uiManager.CanvasUI.ForceOpen);
		GetComponent<InteractEventHandler>().ActivateDialogue(dialogue);
		gameManager.uiManager.CanvasUI.encyclopedia.GetComponent<InventoryActor>().interactable = this;
		//if(isInteracted) Activate(actor);
		//if(!isInteracted) Deactivate(actor);
		EventInteracted.Invoke(actor);
	}
	public override void Activate(GameObject actor)
	{
		//gameManager.uiManager.CanvasUI.encyclopedia.GetComponent<InventoryActor>().interactable = this;
		//gameManager.uiManager.CanvasUI.OpenEnycloepdia();
		particle.SetActive(true);
		isInteracted = true;
		gameManager.uiManager.CanvasUI.OpenEnycloepdia();
		gameManager.uiManager.CanvasUI.EventDialogueClosed.RemoveListener(gameManager.uiManager.CanvasUI.ForceOpen);
		EventActivated.Invoke(actor);
	}
	public override void Deactivate(GameObject actor)
	{
		gameManager.uiManager.CanvasUI.encyclopedia.GetComponent<InventoryActor>().interactable = null;
		gameManager.uiManager.CanvasUI.OpenEnycloepdia();
		gameManager.uiManager.CanvasUI.EventDialogueClosed.RemoveListener(gameManager.uiManager.CanvasUI.ForceOpen);
		EventDeactivated.Invoke(actor);
	}
	




}
