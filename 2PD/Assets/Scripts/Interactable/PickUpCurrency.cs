using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCurrency : Pickup {

	public override void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.GetComponent<PlayerController>())
		{
			col.gameObject.GetComponent<PlayerStats>().AddCurrency(Amount);
			EventPickUp.Invoke();
			Destroy(this.gameObject);
		}
		
	}
}
