using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class UpgradeApplier: MonoBehaviour
{
	GameManager gameManager;

	void Start()
	{
		gameManager = GameManager.instance;
	}

	public UnityEvent EventActivated;
	public void Activate(GameObject receiver, Upgrade upgrade)
	{
		//Return if upgrade requirements are not met
		if(!CheckRequirements(upgrade)) return;
		Health health = receiver.GetComponent<Health>();
		PlayerCombat combat = receiver.GetComponent<PlayerCombat>();

		//Applies the upgrade
		AddHealth(health, upgrade.maxHealth);
		AddDamage(combat, upgrade.damage);
		AddAttackSpeed(combat, upgrade.attackSpeed);

		EventActivated.Invoke();
	}

	public bool CheckRequirements(Upgrade upgrade)
	{
		Inventory inventory = gameManager.sharedInventory;
		// Sets bool of requirements
		foreach (var item in upgrade.requirements)
		{
			if(inventory.GetTotalItemOfType(item.item) >= item.amount)
			{
				item.isAcquired = true;
			}
		}
		//Checks if all requirements have been met
		if(upgrade.requirements.All(x => x.isAcquired == true)) return true;
		return false;
	}

    void AddHealth(Health health, float value)
    {
		if(health == null) return;
        health.maxHealth += value;
		health.AddHp(health.maxHealth);
    }

	void AddDamage(PlayerCombat combat, float value)
    {
		if(combat == null) return;
        combat.damage += value;
    }

    void AddAttackSpeed(PlayerCombat combat, float value)
    {
		if(combat == null) return;
        combat.attackSpeedModifier += value;
		if(combat.attackCooldown <= 0.1) combat.attackCooldown = 0.1f;
    }

	
}


