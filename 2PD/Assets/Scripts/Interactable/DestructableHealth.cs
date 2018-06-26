using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableHealth : Health {
	Destructable ds;
	float hitsToDestroy;
	void Start()
	{
		ds = GetComponent<Destructable>();
		hitsToDestroy = ds.hitsToDestroy;
	}

	public override void DeductHp(float amt, GameObject actor)
	{
		DamageActor da = actor.GetComponent<DamageActor>();
		if(ds.takesHitsToDestroy && ds.type == da.type) 
		{
			hitsToDestroy--;
			if (hitsToDestroy <= 0)
			{
				EventOnHealthDepleted.Invoke();
			}
			return;
		}
		base.DeductHp(amt, actor);
		
		
	}

}
