using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAnimator : MonoBehaviour {

	Animator animator;
	public Interactable pressurepad;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	public void AnimLeft()
	{
		animator.SetTrigger("Left");
	}

	public void AnimRight()
	{
		animator.SetTrigger("Right");
	}

	public void AnimIdle()
	{
		animator.SetTrigger("Idle");
	}
}
