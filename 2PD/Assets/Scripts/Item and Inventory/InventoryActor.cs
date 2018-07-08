using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryActor : MonoBehaviour 
{
	//Invetory Actor is required to edit the inventory of the gameobject
	Inventory inventory;
	GameManager gameManager;
	EncyclopediaUI encylopedia;
	public Interactable interactable;
	public List<InventorySlot> inventorySlots;

	void Start()
	{
		encylopedia = GetComponent<EncyclopediaUI>();
	}

	public void LateUpdate()
	{
		if(gameManager == null) gameManager = GameManager.instance;
	}

	public void UseItemFromSlot(int index)
	{
		if(interactable == null) return;
		if(index + 1 > inventorySlots.Count) return;
		if(inventorySlots[index].item == null || interactable.GetComponent<ZodiacStatue>().itemRequired == null ) return;
		if(inventorySlots[index].item.itemName == interactable.GetComponent<ZodiacStatue>().itemRequired.itemName)
		{
			interactable.Activate(this.gameObject);
		}
	}


}
