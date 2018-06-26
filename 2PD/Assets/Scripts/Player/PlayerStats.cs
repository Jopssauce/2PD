using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour {
	
	Inventory sharedInventory;
	public Health healthComponent;
	public UnityEvent EventOnStatChanged;
	public UnityEvent EventOnDead;
	public ParticleSystem particleOnDeath;




	void Awake()
	{
		healthComponent = GetComponent<Health>();
	}

	void Start()
	{
		sharedInventory = GameManager.instance.sharedInventory;
		healthComponent.EventOnHealthDepleted.AddListener(OnHealthDepleted);
	}
	
	public virtual void OnHealthDepleted()
	{
		if(particleOnDeath != null) Instantiate(particleOnDeath, transform.position, transform.rotation);
		EventOnDead.Invoke();	
	}

	public virtual void AddCurrency(float damage)
	{
		//if(!isServer) return;
		sharedInventory.GetComponent<Currency>().AddCurrency(damage);
		EventOnStatChanged.Invoke();
	}
	
	
}
