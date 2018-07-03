using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SapphireInteractable : Interactable {
	public bool stayOnAfterHit = false;
	public bool isOn = false;
	public bool hasBeenHit = false;
	Animator am;

	public override void Start ()
	{
		base.Start ();
		am = GetComponent<Animator> ();
	}

	void LateUpdate()
	{
		if (stayOnAfterHit && hasBeenHit)
		{
			isOn = true;
			isInteracted = true;
		}
		
	}

	public override void OnTriggerEnter2D(Collider2D col)
	{
		if(!col.gameObject.GetComponent<BulletBehaviour>()) return;
		if(col.gameObject.GetComponent<BulletBehaviour>().gemType == gemType)
		{
			hasBeenHit = true;
			isInteracted = true;
			EventInRange.Invoke(col.gameObject);
			EventInteracted.Invoke(col.gameObject);
			EventActivated.Invoke(col.gameObject);
		} 
		Debug.Log("test");
	}
	public override void OnTriggerExit2D(Collider2D col)
	{
		
	}

	public void PlayAnim()
	{
		am.SetBool ("On", true);
	}
}
