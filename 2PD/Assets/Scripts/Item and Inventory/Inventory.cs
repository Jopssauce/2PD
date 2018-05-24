using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Inventory : MonoBehaviour 
{
	public const int inventorySlots = 10;
	public BaseItem[] itemInventory = new BaseItem[inventorySlots];

	public UnityEvent inventoryChanged;
	//Adds the item and automatically uses a stacking system
	public void AddItem(BaseItem item)
	{		
		int i = 0;
		int prev = 0;
		int toAdd = 0;
		int extraStack = 0;
		int current = 0;
		if (item.isStackable == true)
		{
			if (FindItem(item) != -1)
			{
				i = FindItem(item);
				
				prev = itemInventory[i].stacksAmount;
				toAdd = item.stacksAmount;

				current = toAdd + prev;
				extraStack =  (current - itemInventory[i].maxStacks);	
				if (extraStack < 0)
				{
					extraStack = 0;
				}
				itemInventory[i].stacksAmount = current - extraStack;
				Debug.Log(i + " " + prev + " " + toAdd + " " + extraStack + " " + current + " " + itemInventory[i].stacksAmount);
			}
			else
			{
				if (FindEmptySlot() != -1)
				{
					i = FindEmptySlot();
					itemInventory[i] = Instantiate(item);
					
					
				}
			}
		}
		if (item.isStackable == false)
		{
			if (FindEmptySlot() != -1)
			{
				i = FindEmptySlot();
				itemInventory[i] = Instantiate(item);
				//Debug.Log(i + " " + prev + " " + toAdd + " " + extraStack + " " + current + " " + itemInventory[i].stacksAmount);
			}
		}
		
		
		inventoryChanged.Invoke();
	}

	//Returns index of first empty slot found. Returns -1 if not empty slot fond
	public int FindEmptySlot()
	{
		for (int i = 0; i < itemInventory.Length; i++)
		{
			if (itemInventory[i] == null)
			{
				Debug.Log("Found empty");
				return i;
			}
		}
		Debug.Log("No slots left");
		return -1;
	}

	//Returns index of first item found with the same ITEMID. Returns -1 if no item of type found
	//If item found has full stacks proceed repeat operation
	public int FindItem(BaseItem item)
	{
		for (int i = 0; i < itemInventory.Length; i++)
		{
			if (itemInventory[i] != null)
			{
				if (itemInventory[i].itemID == item.itemID )
				{
					if (itemInventory[i].stacksAmount >= itemInventory[i].maxStacks)
					{
						continue;
					}
					Debug.Log("Found same item of same id");
					return i;
				}
			}
			
		}
		Debug.Log("No item of same id found");
		return -1;
	}

	public void RemoveItem(BaseItem item)
	{
		itemInventory[ FindItem(item)] = null;
		inventoryChanged.Invoke();
	}

	//Switches item slot 1 with slot 2. Only works if both slots are not null
	public void SwitchItem(int slot1, int slot2)
	{
		if(itemInventory[slot1] == null || itemInventory[slot1] == null)
		{
			Debug.Log("No item to switch with"); 
			inventoryChanged.Invoke();
			return;
		} 
		BaseItem temp = itemInventory[slot2];

		itemInventory[slot2] = itemInventory[slot1];
		itemInventory[slot1] = temp;
		inventoryChanged.Invoke();
	}
	//Will only move an item to slot2 and replace any item in the slot2
	public void MoveAndReplaceItem(int slot1, int slot2)
	{
		itemInventory[slot2] = itemInventory[slot1];
		itemInventory[slot1] = null;
		inventoryChanged.Invoke();
	}

	//Simply Returns Item in specified slot 
	public BaseItem GetItemFromSlot(int slot1)
	{
		inventoryChanged.Invoke();
		return itemInventory[slot1];
	}
	

}
