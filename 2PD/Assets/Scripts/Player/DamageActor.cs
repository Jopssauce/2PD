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
		Health player = target.GetComponentInParent<Health>();
		PlayerStats stats = target.GetComponent<PlayerStats>();
		switch (type)
		{
			case DamageTypes.standard :
			player.DeductHp( (damage * stats.globalModifier), this.gameObject );
			break;
			case DamageTypes.fire :
			player.DeductHp( (damage * stats.fireModifier * stats.globalModifier), this.gameObject );
			break;
			case DamageTypes.lava :
			player.DeductHp( (damage * stats.fireModifier * stats.globalModifier), this.gameObject );
			break;
		}
		
	}
}
