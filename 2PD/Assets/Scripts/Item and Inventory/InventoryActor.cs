using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryActor : MonoBehaviour 
{
	//Invetory Actor is required to edit the inventory of the gameobject
	Inventory inventory;
	public BaseItem testItem;
	void Start () {
		//The code below is just test code to sample inventory stacking. Just delete it
		inventory = GetComponent<Inventory>();
		for (int i = 0; i < 700; i++)
		{
			inventory.AddItem(testItem);
		}
		inventory.MoveAndReplaceItem(0,6);
		Debug.Log (inventory.GetItemBySlot(0));
		Debug.Log (inventory.GetItemSlot(testItem));
		Debug.Log (inventory.GetItem(testItem));
		inventory.RemoveItem (testItem);
		inventory.RemoveItemBySlot (9);

		//inventory.RemoveItemBySlot(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
