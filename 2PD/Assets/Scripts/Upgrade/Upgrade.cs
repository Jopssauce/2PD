using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class Upgrade : MonoBehaviour
{
	public string id;
	public List<UpgradeRequirement> requirements;
	GameManager gameManager;

	public UnityEvent EventActivated;

	public virtual void Activate(){}

	public bool CheckRequirements()
	{
		Inventory inventory = gameManager.sharedInventory;
		// Sets bool of requirements
		foreach (var item in requirements)
		{
			if(inventory.GetTotalItemOfType(item.item) >= item.amount)
			{
				item.isAcquired = true;
			}
		}
		//Checks if all requirements have been met
		if(requirements.All(x => x.isAcquired == true)) return true;
		return false;
	}

    protected void AddHealth(Health health, float value)
    {
        health.maxHealth += value;
		health.AddHp(health.maxHealth);
    }

	protected void AddDamage(PlayerCombat combat, float value)
    {
        combat.damage += value;
    }

    protected void AddAttackSpeed(PlayerCombat combat, float value)
    {
        combat.attackSpeedModifier += value;
		if(combat.attackCooldown <= 0.1) combat.attackCooldown = 0.1f;
    }

	
}


