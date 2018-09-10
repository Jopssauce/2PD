using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Inventory : MonoBehaviour 
{
	public int inventorySlots = 10;
	public List<BaseItem> itemInventory;

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
			//Code that auto stacks
			//If no item of same id is found run code
			if (FindItemSlot(item) != -1)
			{
				i = FindItemSlot(item);
				
				prev = itemInventory[i].amount;
				//Adds item stack to add
				toAdd = item.amount;
				//Adds toAdd and prev stacks
				current = toAdd + prev;
				//Extra stacks are remembered to add them to next slot
				extraStack =  (current - itemInventory[i].maxAmount);	
				if (extraStack < 0)
				{
					extraStack = 0;
				}
				//Then extra stacks are subtracted from current
				itemInventory[i].amount = current - extraStack;
				//Debug.Log(i + " " + prev + " " + toAdd + " " + extraStack + " " + current + " " + itemInventory[i].stacksAmount);
			}
			else
			{
				//If there is an empty slot and no item of same ID is found then add new item to inventory
				if (FindEmptySlot() != -1)
				{
					//If an empty slot is found instantiate clone and child item to inventory transform
					i = FindEmptySlot();
					itemInventory[i] = Instantiate(item, transform);
				}
			}
		}
		if (item.isStackable == false)
		{
			if (FindEmptySlot() != -1)
			{
				i = FindEmptySlot();
				itemInventory[i] = Instantiate(item, transform);
				//Debug.Log(i + " " + prev + " " + toAdd + " " + extraStack + " " + current + " " + itemInventory[i].stacksAmount);
			}
		}
		
		
		inventoryChanged.Invoke();
	}

	//Returns index of first empty slot found. Returns -1 if not empty slot fond
	public int FindEmptySlot()
	{
		for (int i = 0; i < itemInventory.Count; i++)
		{
			if (itemInventory[i] == null)
			{
				//Debug.Log("Found empty");
				return i;
			}
		}
		//Debug.Log("No slots left");
		return -1;
	}

	//Returns index of first item found with the same ITEMID. Returns -1 if no item of type found
	public BaseItem GetItem(BaseItem item)
	{
		foreach (var i in itemInventory) 
		{
			if (i != null)
			{
				if (i.itemID == item.itemID )
				{
					//Debug.Log("Found same item of same id");
					return i;
				}
			}	
		}
		//Debug.Log("No item of same id found");
		return null;
	}
	//Finds the first item slot but ignores items with full stacks
	int FindItemSlot(BaseItem item)
	{
		int index = -1;
		foreach (var i in itemInventory) 
		{
			index++;
			if (i != null)
			{
				if (i.itemName == item.itemName )
				{
					if (i.amount >= i.maxAmount)
					{
						continue;
					}
					//Debug.Log("Found same item of same id");
					return index;
				}
			}	
		}
		//Debug.Log("No item of same id found");
		return -1;
	}
	//Gets the first item of type slot number
	public int GetItemSlot(BaseItem item)
	{
		int index = -1;
		foreach (var i in itemInventory) 
		{
			index++;
			if (i != null)
			{
				if (i.itemID == item.itemID )
				{
					return index;
				}
			}	
		}
		//Debug.Log("No item of same id found");
		return -1;
	}

	//Finds item by inventory slot
	public BaseItem GetItemBySlot(int index)
	{
		inventoryChanged.Invoke();
		return itemInventory[index];
	}
	//Removes first item found
	public void RemoveItem(BaseItem item)
	{
		BaseItem temp = itemInventory[ GetItemSlot(item)];
		itemInventory [GetItemSlot (item)] = null;
		Destroy (temp.gameObject);
		inventoryChanged.Invoke();
	}
	public void RemoveItemBySlot(int index)
	{
		BaseItem temp = itemInventory [index];
		itemInventory [index] = null;
		Destroy (temp.gameObject);
		inventoryChanged.Invoke();
	}

	public int GetTotalItemOfType(BaseItem item)
	{
		int value = 0;
		IEnumerable<BaseItem> items = itemInventory.Where(x => x.itemName == item.itemName);
		foreach (var i in items)
		{
			value += item.amount;
		}
		return value;
	}

	//Switches item slot 1 with slot 2. Only works if both slots are not null
	public void SwitchItem(int slot1, int slot2)
	{
		if(itemInventory[slot1] == null || itemInventory[slot1] == null)
		{
			//Debug.Log("No item to switch with"); 
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
		
	
	public bool IsInventoryFull()
	{
		if (FindEmptySlot() == -1 && itemInventory[itemInventory.Count - 1].amount == itemInventory[itemInventory.Count - 1].maxAmount) {
			return true;
		}
		return false;
	}

	public void DeductItems(BaseItem item, int amount)
	{
		int totalItems = GetTotalItemOfType(item);
		if(totalItems >= amount)
		{
			//prevAmount = amount
			//currentAmount = amount - item.amount
			//difference = prevAmount - currentAmount
			//item.amount = item.amount - difference
		}
	}
}
