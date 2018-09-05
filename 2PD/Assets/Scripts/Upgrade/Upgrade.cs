using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthUpgrade<T>
{
	void HealthUpgrade(T value);
}

public interface ICombatUpgrade
{
	void DamageUpgrade(float value);
	void AttackSpeedUpgrade(float value);
}


