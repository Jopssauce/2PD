using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
using System.Linq;

public class Interactable : MonoBehaviour 
{	
	public string id;
	public bool isInteracted;
	public bool isInteractable;
	public bool isCarryable;
	public bool isGrabbable;
	public bool playerCanTrigger = true;
	public PlayerController currentPlayer;
	public GameObject prompt;
	public List<PlayerController> players;
	public List<Interactable> allObjects;
	public enum InteractableType
	{
		touch,
		carry,
		pickup,
	}
	
	public enum GemType
	{
		none,
		Quartz,
		Sapphire,
		Obsidian,
		Diamond
	}

	public enum LockType
	{
		none,
		small,
		big
	}
	public GemType gemType;
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

	void TogglePrompt()
	{
		if(prompt == null) return;
		prompt.GetComponent<SpriteRenderer>().enabled = !prompt.GetComponent<SpriteRenderer>().enabled; 
	}

	public virtual void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && players.Any(player => player.playerID == col.gameObject.GetComponent<PlayerController>().playerID) == false && playerCanTrigger)
		{		
			col.gameObject.GetComponent<PlayerController>().EventOnInteract.AddListener(Interact);
			players.Add(col.gameObject.GetComponent<PlayerController>());
			EventInRange.Invoke();
			isInteractable = true;
			TogglePrompt();
		}
		if(col.gameObject.GetComponent<Interactable>() && allObjects.Any(item => item.GetComponent<Interactable>() == col.gameObject.GetComponent<Interactable>()) == false)
		{
			allObjects.Add(col.gameObject.GetComponent<Interactable>());
			EventInRange.Invoke();
		} 
		

	}
	public virtual void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && players.Any(player => player.playerID == col.gameObject.GetComponent<PlayerController>().playerID && playerCanTrigger))
		{
			players.Remove(col.gameObject.GetComponent<PlayerController>());
			col.gameObject.GetComponent<PlayerController>().EventOnInteract.RemoveListener(Interact);
			EventOutRange.Invoke();
			isInteractable = false;
			TogglePrompt();
		}
		if(col.gameObject.GetComponent<Interactable>() && allObjects.Any(item => item.GetComponent<Interactable>() == col.gameObject.GetComponent<Interactable>()))
		{
			allObjects.Remove(col.gameObject.GetComponent<Interactable>());
			EventOutRange.Invoke();
		} 
	}

	

}
