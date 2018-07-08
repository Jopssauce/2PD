using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZodiacStatue : Interactable 
{
	public BaseItem itemRequired;
	public Sprite on;
	public Sprite off;
	void LateUpdate()
	{
		if(gameManager == null) gameManager = GameManager.instance;
	}
	public override void Interact(GameObject actor)
	{
		//isInteracted = !isInteracted;
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
		gameManager.uiManager.CanvasUI.OpenEnycloepdia();
	}



}
