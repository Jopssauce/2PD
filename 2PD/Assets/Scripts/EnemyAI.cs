using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public Transform Target;
	public float Speed;

	void Update()
	{
		ChasePlayer ();
	}

	void ChasePlayer ()
	{
		float range = Vector2.Distance (transform.position, Target.position);
		if (range < 10.0f) 
		{
			if(range > 1.0f)
			transform.position = Vector2.MoveTowards (transform.position, Target.position, Speed * Time.deltaTime);
		}
	}
}
