using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//[CreateAssetMenu(fileName = "Item", menuName = "Item/Item")]
[System.Serializable]
public class BaseItem : MonoBehaviour 
{
	//Use with prefabs
	//Basic Variables
	public string itemName = "Default";
	public int 	itemID;
	public bool isUsable;
	public bool isConsumable;
	public bool isStackable;
	public bool isEquipable;
	public int maxStacks = 64;
	
	public int stacksAmount = 1;

	public Sprite itemSprite;
	
	//Unity Events that can be listened to with AddListener()
	public UnityEvent itemUsed;
	public UnityEvent itemNameChanged;
	public UnityEvent isUsableChanged;
	public UnityEvent isStackableChanged;
	public UnityEvent isEquipableChanged;
	public UnityEvent maxStacksChanged;
	public UnityEvent stacksAmountChanged;

	//Uses the item and invokes itemUsed Event
	public virtual void UseItem()
	{
		Debug.Log(itemName + " Item used");
		itemUsed.Invoke();
	}

	/*public BaseItem (BaseItem item)
	{
		item.itemName = itemName;
		item.itemID = itemID;
		item.isUsable = isUsable;
		item.isUsable = itemSprite;
		item.isStackable = isStackable;
		item.isEquipable = isEquipable;
		item.maxStacks = maxStacks;
		item.stacksAmount = stacksAmount;
		item.itemSprite = itemSprite;

	}*/
}
