using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class InteractableEvents : UnityEvent<GameObject> {}
public class Interactable : MonoBehaviour 
{	
	public string id;
	public bool stayInteracted;
	public bool isInteracted;
	public bool isInteractable;
	public bool isGrabbable;
	public bool playerCanTrigger = true;
	public int requiredPlayers;
	public PlayerController currentPlayer;
	public GameObject prompt;
	public List<PlayerController> players;
	public List<Interactable> allObjects;
	public InteractableChecker checker;
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
	public InteractableEvents EventInRange;
	public InteractableEvents EventOutRange;
	public UnityEvent EventActivating;
	public UnityEvent EventDeactivating;

	public InteractableEvents EventInteracted;
	public InteractableEvents EventActivated;
	public InteractableEvents EventDeactivated;


	public GameManager gameManager;

	public virtual void Start()
	{
		currentPlayer = null;
		isInteractable = false;
		gameManager = GameManager.instance;
		checker = GetComponent<InteractableChecker>();
	}

	public virtual void Interact(GameObject actor){}
	public virtual void Activate(GameObject actor){}
	public virtual void Deactivate(GameObject actor){}

	void TogglePrompt()
	{
		if(prompt == null) return;
		prompt.GetComponent<SpriteRenderer>().enabled = !prompt.GetComponent<SpriteRenderer>().enabled; 
	}

	public virtual void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && players.Any(player => player.ID == col.gameObject.GetComponent<PlayerController>().ID) == false && playerCanTrigger)
		{		
			col.gameObject.GetComponent<PlayerController>().EventOnInteract.AddListener(Interact);
			players.Add(col.gameObject.GetComponent<PlayerController>());
			EventInRange.Invoke(col.gameObject);
			isInteractable = true;
			TogglePrompt();
		}
		if(col.gameObject.GetComponent<Interactable>() && allObjects.Any(item => item.GetComponent<Interactable>() == col.gameObject.GetComponent<Interactable>()) == false)
		{
			allObjects.Add(col.gameObject.GetComponent<Interactable>());
			EventInRange.Invoke(col.gameObject);
		} 
		

	}
	public virtual void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && players.Any(player => player.ID == col.gameObject.GetComponent<PlayerController>().ID && playerCanTrigger))
		{
			players.Remove(col.gameObject.GetComponent<PlayerController>());
			col.gameObject.GetComponent<PlayerController>().EventOnInteract.RemoveListener(Interact);
			EventOutRange.Invoke(col.gameObject);
			isInteractable = false;
			TogglePrompt();
		}
		if(col.gameObject.GetComponent<Interactable>() && allObjects.Any(item => item.GetComponent<Interactable>() == col.gameObject.GetComponent<Interactable>()))
		{
			allObjects.Remove(col.gameObject.GetComponent<Interactable>());
			EventOutRange.Invoke(col.gameObject);
		} 
	}

	

}
