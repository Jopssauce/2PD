using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointAnim : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	public void ChangeAnimState(bool State)
	{
		anim.SetBool ("CheckpointOn", State);
	}
}
