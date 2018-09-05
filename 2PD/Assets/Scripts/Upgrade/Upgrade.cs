using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthUpgrade<T>
{
	void HealthUpgrade(T value);
}

public interface IDamageUpgrade<T>
{
	void DamageUpgrade(T value);
}

public interface IAttackSpeedUpgrade<T>
{
	void AttackSpeedUpgrade(T value);
}
