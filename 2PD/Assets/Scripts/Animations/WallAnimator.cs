using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class WallAnimator : MonoBehaviour {

	Animator animator;
	public List<Interactable> pressurepads;
	

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	public void AnimLeft()
	{
		if(pressurepads.All(pad => pad.isInteracted == false)) return;
		animator.SetTrigger("Left");
	}

	public void AnimRight()
	{
		if(pressurepads.All(pad => pad.isInteracted == false)) return;
		animator.SetTrigger("Right");
	}

	public void AnimIdle()
	{
		animator.SetTrigger("Idle");
	}
}
