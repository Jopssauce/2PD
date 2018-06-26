using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : PlayerStats 
{
	void Start()
	{
		healthComponent.EventOnHealthDepleted.AddListener(DestroySelf);
	}


	void DestroySelf()
	{
		Destroy(this.gameObject);
	}
}
