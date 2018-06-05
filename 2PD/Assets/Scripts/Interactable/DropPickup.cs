using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DropPickup : MonoBehaviour {

	public bool dropOnDestroy = false;
	public List<Pickup> pickupsToDrop;
	public List<Pickup> guaranteedPickupsToDrop;
	public int itemDropAmt = 3;

	public UnityEvent EventOnDrop;


	public void Start () 
	{
		EventOnDrop.AddListener(DropItems);
	}



	void DropItemsRandom()
	{
		
		int rItem = Random.Range(0, pickupsToDrop.Count);
		Pickup item = Instantiate(pickupsToDrop [rItem], this.transform.position, pickupsToDrop [rItem].transform.rotation);
		item.EnableGravity();
		
	}

	void DropGuaranteedItems()
	{
		foreach (var item in guaranteedPickupsToDrop)
		{
			Pickup pickup = Instantiate(item, this.transform.position, item.transform.rotation);
			pickup.EnableGravity();
		}
	}

	public void DropItems()
	{
		for (int i = 0; i < itemDropAmt; i++)
		{
			DropItemsRandom();
		}
		DropGuaranteedItems();
	}

}
