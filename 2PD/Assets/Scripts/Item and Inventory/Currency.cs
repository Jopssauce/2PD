﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Currency : MonoBehaviour {

	public float gold;
	public UnityEvent onCurrencyChanged;

	void Start()
	{
		gold = 200;
	}

	public virtual void AddCurrency(float amt)
	{
		//if(!isServer) return;
		gold += amt;
		Debug.Log("currency");
		onCurrencyChanged.Invoke();
	}
	
	public virtual void DeductCurrency(float amt)
	{
		//if(!isServer) return;
		gold -= amt;
		Debug.Log("currency");
		onCurrencyChanged.Invoke();
	}
}

