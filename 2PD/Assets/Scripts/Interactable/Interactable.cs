using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class Interactable : MonoBehaviour 
{	
	public string id;
	bool isHighestPriority;
	public bool isInteractable;
	public bool isCarryable;
	public PlayerController currentPlayer;
	public Sprite interactableSprite;

	public enum InteractableType
	{
		touch,
		carry,
		pickup
	}

	public enum LockType
	{
		none,
		small,
		big
	}
	public InteractableType interactableType;
	public LockType lockType;
	public UnityEvent EventInteract;
	public UnityEvent EventInRange;
	public UnityEvent EventOutRange;
	public UnityEvent EventInteracted;
	public UnityEvent EventInteractable;

	public GameManager gameManager;

	public virtual void Start()
	{
		currentPlayer = null;
		isInteractable = false;
		gameManager = GameManager.instance;

	}

	public virtual void Interact(PlayerController player){}

	public virtual void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			currentPlayer = col.gameObject.GetComponent<PlayerController>();
			EventInRange.Invoke();
			isInteractable = true;
		}
		
	}
	public virtual void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			EventOutRange.Invoke();
			isInteractable = false;
		}
	}

}
