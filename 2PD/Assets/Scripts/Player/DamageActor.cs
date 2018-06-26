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
	public Interactable.GemType type;
	

	public void DealDamage(float damage, GameObject target, DamageTypes type)
	{
		PlayerStats player = target.GetComponentInParent<PlayerStats>();
		switch (type)
		{
			case DamageTypes.standard :
			player.DeductHp( (damage * player.globalModifier) );
			break;
			case DamageTypes.fire :
			player.DeductHp( (damage * player.fireModifier * player.globalModifier) );
			break;
			case DamageTypes.lava :
			player.DeductHp( (damage * player.fireModifier * player.globalModifier) );
			break;
		}
		
	}
}
