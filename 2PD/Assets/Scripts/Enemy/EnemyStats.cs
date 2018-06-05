using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : PlayerStats 
{
	void Start()
	{
		EventOnDead.AddListener(DestroySelf);
	}


	void DestroySelf()
	{
		if(particleOnDeath != null) Instantiate(particleOnDeath, transform.position, particleOnDeath.transform.rotation);
		Destroy(this.gameObject);
	}
}
