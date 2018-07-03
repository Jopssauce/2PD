using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour {
	public bool destroyOnHealthDepleted;
	bool isInvulnerable = false;
	bool isInvulnerabilityTimerStarted;
	public float health;
	public float maxHealth;
	public float invulnerabilityTimer = 1;
	public UnityEvent EventOnHealthChange;
	public UnityEvent EventOnHealthDepleted;
	public UnityEvent EventOnDestroy;
	public UnityEvent EventStartingInvulnerability;
	public UnityEvent EventEndingInvulnerability;

	[Header("Damage Modifiers")]
	public float globalModifier = 1;
	public float fireModifier = 1;
	public float lavaModifier = 1;

	IEnumerator invulTimer;
	void Awake()
	{
		health = maxHealth;
	}
	
	public virtual void DeductHp(float amt)
	{
		if (amt <= 0) amt = 0;
		//if(!isServer) return;
		health -= amt;
		if(health <= 0)
		{
			health = 0;
			EventOnHealthDepleted.Invoke();	
			if(destroyOnHealthDepleted) OnHealthDepeleted();
			Debug.Log("Depleted");
		} 
		
		EventOnHealthChange.Invoke();
	}

	public virtual void DeductHp(float amt, GameObject actor)
	{

		if(isInvulnerable)
		{
			return;
		} 

		if (amt <= 0) amt = 0;
		//if(!isServer) return;
		health -= amt;
		if(health <= 0)
		{
			health = 0;
			EventOnHealthDepleted.Invoke();
			if(destroyOnHealthDepleted) OnHealthDepeleted();
			Debug.Log("Depleted");	
		} 
		Debug.Log("Hit");
		EventOnHealthChange.Invoke();
		if(!isInvulnerable)
		{
			if (!isInvulnerabilityTimerStarted)
			{
				isInvulnerable = true;
				invulTimer = InvulnerabilityTimer();
				StartCoroutine(invulTimer);
			}

		}
	}

	public virtual void AddHp(float amt)
	{
		//if(!isServer) return;
		health += amt;
		if(health > maxHealth) health = maxHealth;
		Debug.Log("heal");
		EventOnHealthChange.Invoke();
	}
	
	public void OnHealthDepeleted()
	{
		Destroy(this.gameObject);
	}

	public IEnumerator InvulnerabilityTimer()
	{
		StartInvulnerability();
		yield return new WaitForSeconds(invulnerabilityTimer);
		EndInvulnerability();
	}

	public void StartInvulnerability()
	{
		isInvulnerabilityTimerStarted = true;
		EventStartingInvulnerability.Invoke();
	}

	public void EndInvulnerability()
	{
		isInvulnerabilityTimerStarted = false;
		isInvulnerable = false;
		EventEndingInvulnerability.Invoke();
	}

	void OnDestroy()
	{
		EventOnDestroy.Invoke();
	}
}
