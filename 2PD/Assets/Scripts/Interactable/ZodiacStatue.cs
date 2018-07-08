using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZodiacStatue : Interactable 
{
	public BaseItem itemRequired;
	bool isToggled;
	public Sprite on;
	public Sprite off;
	void LateUpdate()
	{
		if(gameManager == null) gameManager = GameManager.instance;
	}
	public override void Interact(GameObject actor)
	{
		if(isInteracted) return;
		ToggleEncylopedia();
		//if(isInteracted) Activate(actor);
		//if(!isInteracted) Deactivate(actor);
		EventInteracted.Invoke(actor);
	}
	public override void Activate(GameObject actor)
	{
		//gameManager.uiManager.CanvasUI.encyclopedia.GetComponent<InventoryActor>().interactable = this;
		//gameManager.uiManager.CanvasUI.OpenEnycloepdia();
		isInteracted = true;
		ToggleEncylopedia();
		EventActivated.Invoke(actor);
	}
	public override void Deactivate(GameObject actor)
	{
		//gameManager.uiManager.CanvasUI.encyclopedia.GetComponent<InventoryActor>().interactable = null;
		//gameManager.uiManager.CanvasUI.OpenEnycloepdia();
		EventDeactivated.Invoke(actor);
	}
	
	public void ToggleEncylopedia()
	{
		isToggled = !isToggled;
		gameManager.uiManager.CanvasUI.OpenEnycloepdia();
		if(!isToggled)gameManager.uiManager.CanvasUI.encyclopedia.GetComponent<InventoryActor>().interactable = this;
		if(isToggled)gameManager.uiManager.CanvasUI.encyclopedia.GetComponent<InventoryActor>().interactable = this;
	}



}
