using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour {
	//[SyncVar]
	public float hp;
	public float maxHp;
	public float gold = 200;
	public UnityEvent EventOnStatChanged;
	void Awake()
	{
		hp = maxHp;
		gold = 200;
	}
	
	public void Damage(float damage)
	{
		//if(!isServer) return;
		hp -= damage;
		if(hp < 0) hp = 0;
		Debug.Log("Hit");
		EventOnStatChanged.Invoke();
	}
	public void AddHp(float damage)
	{
		//if(!isServer) return;
		hp += damage;
		if(hp > maxHp) hp = maxHp;
		Debug.Log("heal");
		EventOnStatChanged.Invoke();
	}
	public void AddCurrency(float damage)
	{
		//if(!isServer) return;
		gold += damage;
		Debug.Log("currency");
		EventOnStatChanged.Invoke();
	}
	
	
}
