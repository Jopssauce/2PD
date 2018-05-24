using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCurrency : Pickup {

	public override void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.GetComponent<PlayerController>())
		{
			col.gameObject.GetComponent<PlayerStats>().AddCurrency(Amount);
			EventPickUp.Invoke();
			Destroy(this.gameObject);
		}
		
	}
}
