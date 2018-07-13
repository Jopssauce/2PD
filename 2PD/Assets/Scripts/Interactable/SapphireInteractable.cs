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

	public override void Activate (GameObject actor)
	{
		hasBeenHit = true;
		isInteracted = true;
		PlayAnimOn ();
		EventInRange.Invoke(actor);
		EventInteracted.Invoke(actor);
		EventActivated.Invoke(actor);
	}

	public override void Deactivate (GameObject actor)
	{
		hasBeenHit = false;
		isInteracted = false;
		PlayAnimOff ();
		EventInteracted.Invoke(actor);
		EventDeactivated.Invoke(actor);
	}


	public override void OnTriggerEnter2D(Collider2D col)
	{
		if(!col.gameObject.GetComponent<BulletBehaviour>()) return;
		if(col.gameObject.GetComponent<BulletBehaviour>().gemType == gemType)
		{
			Activate (col.gameObject);
		} 
		Debug.Log("test");
	}
	public override void OnTriggerExit2D(Collider2D col)
	{
		
	}

	public void PlayAnimOn()
	{
		am.SetBool ("Off", false);
		am.SetBool ("On", true);
	}

	public void PlayAnimOff()
	{
		am.SetBool ("On", false);
		am.SetBool ("Off", true);
	}
}
