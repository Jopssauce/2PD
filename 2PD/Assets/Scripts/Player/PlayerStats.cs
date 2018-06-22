using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour {
	
	Inventory sharedInventory;
	public float hp;
	public float maxHp;
	public UnityEvent EventOnStatChanged;
	public UnityEvent EventOnDead;
	public ParticleSystem particleOnDeath;
	[Header("Damage Modifiers")]
	public float globalModifier = 1;
	public float fireModifier = 1;
	public float lavaModifier = 1;



	void Awake()
	{
		hp = maxHp;
	}

	void Start()
	{
		sharedInventory = GameManager.instance.sharedInventory;
	}
	
	public virtual void DeductHp(float damage)
	{
		if (damage < 0) damage = 0;
		//if(!isServer) return;
		hp -= damage;
		if(hp < 0)
		{
			hp = 0;
			if(particleOnDeath != null) Instantiate(particleOnDeath, transform.position, transform.rotation);
			EventOnDead.Invoke();	
		} 
		Debug.Log("Hit");
		EventOnStatChanged.Invoke();
	}
	public virtual void AddHp(float damage)
	{
		//if(!isServer) return;
		hp += damage;
		if(hp > maxHp) hp = maxHp;
		Debug.Log("heal");
		EventOnStatChanged.Invoke();
	}
	public virtual void AddCurrency(float damage)
	{
		//if(!isServer) return;
		sharedInventory.GetComponent<Currency>().AddCurrency(damage);
		EventOnStatChanged.Invoke();
	}
	
	
}
