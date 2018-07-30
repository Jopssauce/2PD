using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour {
	public Interactable objectToActOn;
	public bool canAction;
	bool isLiftable;
	bool isPushing;
	// Use this for initialization
	void Start () 
	{
		canAction = false;
		GetComponent<PlayerController>().EventOnInteract.AddListener(LetGo);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Grab();
	}


	public void Grab()
	{
		if (objectToActOn != null && objectToActOn.isGrabbable == true)
		{
			objectToActOn.transform.parent = GetComponent<PlayerController>().directions[GetComponent<PlayerController>().lastDirection].transform;
			objectToActOn.transform.localPosition = Vector3.zero;
		}

	}

	public void LetGo(GameObject obj)
	{
		if (objectToActOn != null && objectToActOn.isGrabbable == true)
		{
			objectToActOn.transform.SetParent(null);
			objectToActOn = null;
		}
		
	}
}
