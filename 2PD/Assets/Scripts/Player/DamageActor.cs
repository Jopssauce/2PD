using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageActor : MonoBehaviour {
	public enum DamageTypes
	{
		standard,
		fire
	}

	public DamageTypes damageType;
	

	public void DealDamage(float damage, GameObject target, DamageTypes type)
	{
		PlayerStats player = target.GetComponent<PlayerStats>();
		switch (type)
		{
			case DamageTypes.standard :
			player.DeductHp(damage);
			break;
			case DamageTypes.fire :
			player.DeductHp(damage * player.fireModifier);
			break;
		}
		
	}
}
