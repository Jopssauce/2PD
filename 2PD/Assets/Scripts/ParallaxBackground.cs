using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour {

	public float ScrollSpeed = 1.0f;
	public float ScrollOffset;
	private Vector2 startPos;
	private float newPos;
	// Use this for initialization
	void Start () 
	{
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		newPos = Mathf.Repeat (Time.time * -ScrollSpeed, ScrollOffset);
		transform.position = startPos + (Vector2.right * newPos);
	}
}
