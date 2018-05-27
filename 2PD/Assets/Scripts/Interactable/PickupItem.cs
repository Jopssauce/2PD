using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Pickup 
{
	public bool isSharedItem;
	public BaseItem item;
	Inventory sharedInventory;
	void Start()
	{
		gameManager = GameManager.instance;
		sharedInventory = gameManager.sharedInventory;
	}

	public override void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.GetComponent<PlayerController>())
		{
			sharedInventory.AddItem(item);
			EventPickUp.Invoke();
			Destroy(this.gameObject);
		}
		
	}

}
