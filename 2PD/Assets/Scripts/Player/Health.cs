using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour {
	public float health;
	public float maxHealth;
	public UnityEvent EventOnHealthChange;
	public UnityEvent EventOnHealthDepleted;

	void Awake()
	{
		health = maxHealth;
	}
	
	public virtual void DeductHp(float amt)
	{
		if (amt < 0) amt = 0;
		//if(!isServer) return;
		health -= amt;
		if(health < 0)
		{
			health = 0;
			EventOnHealthDepleted.Invoke();	
		} 
		Debug.Log("Hit");
		EventOnHealthChange.Invoke();
	}
	public virtual void AddHp(float amt)
	{
		//if(!isServer) return;
		health += amt;
		if(health > maxHealth) health = maxHealth;
		Debug.Log("heal");
		EventOnHealthChange.Invoke();
	}
}
