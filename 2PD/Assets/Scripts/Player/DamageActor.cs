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
		switch (type)
		{
			case DamageTypes.standard :
			player.DeductHp( (damage * player.globalModifier), this.gameObject );
			break;
			case DamageTypes.fire :
			player.DeductHp( (damage * player.fireModifier * player.globalModifier), this.gameObject );
			break;
			case DamageTypes.lava :
			player.DeductHp( (damage * player.fireModifier * player.globalModifier), this.gameObject );
			break;
		}
		
	}

	public void DealDamageThrougInvul(float damage, GameObject target, DamageTypes type)
	{
		Health player = target.GetComponentInParent<Health>();
		switch (type)
		{
			case DamageTypes.standard :
			player.DeductHpWhileInvulnerable( (damage * player.globalModifier) );
			break;
			case DamageTypes.fire :
			player.DeductHpWhileInvulnerable( (damage * player.fireModifier * player.globalModifier) );
			break;
			case DamageTypes.lava :
			player.DeductHpWhileInvulnerable( (damage * player.fireModifier * player.globalModifier) );
			break;
		}
		
	}
}
