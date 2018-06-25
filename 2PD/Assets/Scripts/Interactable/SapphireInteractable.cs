using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SapphireInteractable : Interactable {
	public bool stayOnAfterHit = false;
	bool hasBeenHit = false;
	void LateUpdate()
	{
		if (stayOnAfterHit && hasBeenHit)
		{
			EventInRange.Invoke();
		}
		
	}

	public override void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.GetComponent<BulletBehaviour>().gemType == gemType)
		{
			EventInRange.Invoke();
			hasBeenHit = true;
		} 
	}
	public override void OnTriggerExit2D(Collider2D col)
	{
		
	}
}
