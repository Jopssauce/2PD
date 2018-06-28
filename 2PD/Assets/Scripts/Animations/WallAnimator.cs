using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class WallAnimator : MonoBehaviour {

	Animator animator;
	

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	public void AnimLeft()
	{
		Debug.Log("test");
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
