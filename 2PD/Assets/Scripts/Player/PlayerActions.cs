using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour {
	public Interactable objectToActOn;
	public bool canAction;
	bool isLiftable;
	// Use this for initialization
	void Start () 
	{
		canAction = false;
		GetComponent<PlayerController>().EventOnInteract.AddListener(Throw);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Lift();
	}

	public void Lift()
	{
		if (objectToActOn != null && objectToActOn.isCarryable == true)
		{
			objectToActOn.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.2f, this.transform.position.z);
		}
	}

	public void Throw(PlayerController player)
	{
		if (objectToActOn != null && objectToActOn.GetComponent<Carryable>())
		{
			objectToActOn.GetComponent<Rigidbody2D>().AddForce( (Vector2)this.GetComponent<PlayerController>().direction * 100);
			objectToActOn.GetComponent<Carryable>().EnableGravity();
			objectToActOn.currentPlayer = null;
			objectToActOn = null;
		}
	}
}
