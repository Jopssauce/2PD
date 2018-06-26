using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SapphireInteractable : Interactable {
	public bool stayOnAfterHit = false;
	bool isOn = false;
	bool hasBeenHit = false;
	void LateUpdate()
	{
		if (stayOnAfterHit && hasBeenHit)
		{
			isOn = true;
		}
		
	}

	public override void OnTriggerEnter2D(Collider2D col)
	{
		if(!col.gameObject.GetComponent<BulletBehaviour>()) return;
		if(col.gameObject.GetComponent<BulletBehaviour>().gemType == gemType)
		{
			EventInRange.Invoke();
			hasBeenHit = true;
		} 
		Debug.Log("test");
	}
	public override void OnTriggerExit2D(Collider2D col)
	{
		
	}
}
