using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAnimator : MonoBehaviour {

	Animator animator;
	public Interactable pressurepad;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	void AnimLeft()
	{
		animator.SetTrigger("Left");
	}

	void AnimRight()
	{
		animator.SetTrigger("Right");
	}

	void AnimIdle()
	{
		animator.SetTrigger("Idle");
	}
}
