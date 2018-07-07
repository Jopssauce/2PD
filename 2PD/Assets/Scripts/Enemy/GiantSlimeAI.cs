using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantSlimeAI : EnemyAI 
{
	public float spawnTimer;
	public float spawnCooldown = 6;
	public bool isActivated;
	bool isOnCooldown = false;
	public Spawner spawner;
	public Health health;

	IEnumerator startTimer;
	IEnumerator startSpawnCooldown;

	void Start()
	{
		health.EventOnHealthChange.AddListener (Activate);
	}

	public IEnumerator StartTimer()
	{
		isActivated = true;
		spawner.EventActivate.Invoke ();
		yield return new WaitForSeconds (spawnTimer);
		isActivated = false;
		Deactivate ();

	}

	public IEnumerator StartSpawnCooldown()
	{
		isOnCooldown = true;
		yield return new WaitForSeconds (spawnCooldown);
		isOnCooldown = false;

	}

	public void Activate()
	{
		if (!isActivated && !isOnCooldown) 
		{
			startTimer = StartTimer ();
			StartCoroutine (startTimer);

			startSpawnCooldown = StartSpawnCooldown();
			StartCoroutine (startSpawnCooldown);
		}
	}

	public void Deactivate()
	{
		spawner.EventDeactivate.Invoke ();
	}


}
