using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destructable : MonoBehaviour {
	public UnityEvent EventOnHit;
	public LayerMask layerMask;
	
	public GameObject itemtoDrop;

	public void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log(layerMask);
		if (col.gameObject.layer == 10)
		{
			EventOnHit.Invoke();
			if (itemtoDrop != null)
			{
				DropItem(itemtoDrop);
			}
			//Drop item if any
			Destroy(this.gameObject);
		}
		
	}

	public virtual void DropItem(GameObject item)
	{
		Instantiate(item, this.transform.position, item.transform.rotation).GetComponent<Pickup>().EnableGravity();
	}
	
}
