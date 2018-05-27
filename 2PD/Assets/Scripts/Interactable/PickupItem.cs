using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Pickup 
{
	public BaseItem item;

	public override void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.GetComponent<PlayerController>())
		{
			//Add item to inventory
			EventPickUp.Invoke();
			Destroy(this.gameObject);
		}
		
	}

}
