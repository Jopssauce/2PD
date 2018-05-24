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
		for (int i = 0; i < 645; i++)
		{
			inventory.AddItem(testItem);
		}
		//inventory.MoveAndReplaceItem(1,6);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
