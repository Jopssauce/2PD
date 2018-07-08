using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InventoryActor : MonoBehaviour 
{
	//Invetory Actor is required to edit the inventory of the gameobject
	Inventory inventory;
	GameManager gameManager;
	EncyclopediaUI encylopedia;
	PersistentDataManager dataManager;
	public Interactable interactable;
	public List<InventorySlot> inventorySlots;

	void Start()
	{
		encylopedia = GetComponent<EncyclopediaUI>();
		dataManager = PersistentDataManager.instance;
		foreach (var item in inventorySlots)
		{
			if(item.item != null) 
			{
				if(dataManager.sharedInventory.itemInventory.Where(gem => gem != null).Any(gem => gem.itemName == item.item.itemName)) item.image.color = new Color32(255,255,255,255);
			}
			
		}
	
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
			Debug.Log("test");
		}
	}


}
