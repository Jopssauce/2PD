using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageActor : MonoBehaviour {
	public enum DamageTypes
	{
		standard,
		fire,
		lava
	}

	public DamageTypes damageType;
	

	public void DealDamage(float damage, GameObject target, DamageTypes type)
	{
		PlayerStats player = target.GetComponentInParent<PlayerStats>();
		switch (type)
		{
			case DamageTypes.standard :
			player.DeductHp(damage + (damage * player.globalModifier) );
			break;
			case DamageTypes.fire :
			player.DeductHp(damage + (damage + player.fireModifier * player.globalModifier) );
			break;
			case DamageTypes.lava :
			player.DeductHp(damage + (damage + player.fireModifier * player.globalModifier) );
			break;
		}
		
	}
}
