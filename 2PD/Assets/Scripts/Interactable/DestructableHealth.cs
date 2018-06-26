using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableHealth : Health {
	Destructable ds;
	float hitsToDestroy;
	void Start()
	{
		ds = GetComponent<Destructable>();
	}

	public override void DeductHp(float amt, GameObject actor)
	{
		base.DeductHp(amt, actor);
		if (health < 0)
		{
			if (actor.gameObject.GetComponent<DamageActor>())
			{
			if (ds.itemtoDrop != null)
			{
				ds.DropItem(ds.itemtoDrop);
			}
			//Drop item if any
			Destroy(this.gameObject);
			}
		}
		
	}

}
