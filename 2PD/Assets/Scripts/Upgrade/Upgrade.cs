using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="Upgrade", menuName="Upgrades/Upgrade")]
public class Upgrade : ScriptableObject 
{
	// Values to upgrade
	public float maxHealth;
	public float damage;
	public float attackSpeed;
	[Range(0.0f, 1.0f)]
	public float dodgeChance;
	public float damageReduction;

	public int cost;
	public List<UpgradeRequirement> requirements;
}
