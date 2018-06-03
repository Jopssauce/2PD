using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimator : MonoBehaviour {

	Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	public void AnimOpen()
	{
		animator.SetTrigger("Open");
	}

	public void AnimClose()
	{
		animator.SetTrigger("Close");
	}

	public void AnimIdle()
	{
		animator.SetTrigger("Idle");
	}
}
