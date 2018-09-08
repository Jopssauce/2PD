using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : ScriptableObject 
{
	// Values to upgrade
	public float maxHealth;
	public float damage;
	public float attackSpeed;

	public List<UpgradeRequirement> requirements;
}
