using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : Interactable {

	public List<Pickup> itemsToDrop;
	public List<Pickup> guaranteedItemsToDrop;
	public int itemDropAmt = 3;

	public Sprite ChestOpen;
	public Sprite ChestClose;

	private SpriteRenderer spritePlace;

	public override void Start () 
	{
		currentPlayer = null;
		isInteractable = false;
		gameManager = GameManager.instance;

		EventInteract.AddListener(OpenContainer);
		spritePlace = GetComponent<SpriteRenderer> ();
	}

	void Update()
	{
		if(isInteracted) isInteractable = false;
	}
	
	public override void Interact(PlayerController player)
	{
		//if (isInteractable == true && player == currentPlayer)
		//{
			EventInteract.Invoke();
		//}
	}

	void DropItemsRandom()
	{
		
		int rItem = Random.Range(0, itemsToDrop.Count);
		Pickup item = Instantiate(itemsToDrop [rItem], this.transform.position, itemsToDrop [rItem].transform.rotation);
		item.EnableGravity();
		
	}

	void DropGuaranteedItems()
	{
		foreach (var item in guaranteedItemsToDrop)
		{
			Pickup pickup = Instantiate(item, this.transform.position, item.transform.rotation);
			pickup.EnableGravity();
		}
	}

	void OpenContainer()
	{
		if(isInteracted == true) return;
		for (int i = 0; i < itemDropAmt; i++)
		{
			DropItemsRandom();
		}
		DropGuaranteedItems();
		isInteracted = true;
		spritePlace.sprite = ChestOpen;
	}
}
