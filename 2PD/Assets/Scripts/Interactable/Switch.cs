using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Switch : Interactable {
	public int playerIDRequired;
	public int buttonID;

	public Sprite off;
	public Sprite on;

	public bool canDeactivate = false;
	bool isActivated;
	
	public override void Start()
	{
		base.Start();
	}

	public override void Interact(GameObject obj)
	{
		PlayerController player = obj.GetComponent<PlayerController>();
		if (player.ID == playerIDRequired || playerIDRequired == -1)
		{
			isActivated = !isActivated;
			if(isActivated) Activate(obj);
			if(!isActivated && canDeactivate) Deactivate(obj);
			
		}
		EventInteracted.Invoke(obj);
	}

	public override void Activate(GameObject actor)
	{
		isInteracted = true;
		if(GetComponent<SpriteRenderer>())GetComponent<SpriteRenderer>().sprite = on;
		EventActivated.Invoke(actor);
	}

	public override void Deactivate(GameObject actor)
	{
		isInteracted = false;
		if(GetComponent<SpriteRenderer>())GetComponent<SpriteRenderer>().sprite = off;
		EventDeactivated.Invoke(actor);
	}


	

}
