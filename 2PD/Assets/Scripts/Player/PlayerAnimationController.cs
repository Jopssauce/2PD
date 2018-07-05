using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour 
{
	Animator animator;
	PlayerController playerController;

	void Start()
	{
		animator = GetComponent<Animator> ();
		playerController = GetComponent<PlayerController> ();
		playerController.EventOnMove.AddListener (AnimationTrigger);
	}

	void FixedUpdate()
	{
		
		if(playerController.isMoving == false ) animator.SetBool ("IsWalking", false);
		animator.SetFloat ("X", playerController.direction.x);
		animator.SetFloat ("Y", playerController.direction.y);
		
	}

	void AnimationTrigger()
	{
		animator.SetBool ("IsWalking", true);
	}

	public void NotAttacking()
	{
		animator.SetBool("IsAttacking", false);
	}
	public void IsAttacking()
	{
		animator.SetBool("IsAttacking", true);
	}

}
