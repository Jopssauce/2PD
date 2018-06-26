using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destructable : MonoBehaviour {
	public UnityEvent EventOnHit;
	public LayerMask layerMask;
	
	public Interactable.GemType type;
	public GameObject itemtoDrop;
	
	Health health;

	void Start()
	{
		health = GetComponent<Health>();
	}


	public virtual void DropItem(GameObject item)
	{
		Instantiate(item, this.transform.position, item.transform.rotation).GetComponent<Pickup>().EnableGravity();
	}

	
}
