﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Barrier : MonoBehaviour 
{
	public List<EnemyController> enemies;

	void LateUpdate()
	{
		DestroyBarrier();
	}
	
	public void DestroyBarrier()
	{
		if (enemies.All(enemies => enemies == null))
		{
			Destroy(this.gameObject, 0.5f);
		}
	}
}