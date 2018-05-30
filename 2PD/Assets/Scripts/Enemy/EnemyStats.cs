using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : PlayerStats 
{

	public override void DeductHp(float damage)
	{
		base.DeductHp(damage);
		if (hp <= 0)
		{
			if(particleOnDeath != null) Instantiate(particleOnDeath, transform.position, particleOnDeath.transform.rotation);
			Destroy(this.gameObject);
		}
	}
}
