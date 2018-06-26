using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destructable : MonoBehaviour {
	public UnityEvent EventOnHit;
	public bool takesHitsToDestroy;
	public float hitsToDestroy;
	public Interactable.GemType type;
	public GameObject itemtoDrop;
	
	Health health;

	void Start()
	{
		health = GetComponent<Health>();
		health.EventOnHealthDepleted.AddListener(DropItem);
	}


	public virtual void DropItem()
	{
		Instantiate(itemtoDrop, this.transform.position, itemtoDrop.transform.rotation).GetComponent<Pickup>().EnableGravity();
		Destroy(this.gameObject);
	}

	
}
