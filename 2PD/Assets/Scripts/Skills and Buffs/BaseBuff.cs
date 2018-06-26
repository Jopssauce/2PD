﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseBuff : MonoBehaviour 
{
	public enum BuffType
	{
		standard,
		infuse
	}
	public string ID;
	public string buffName;
	public Sprite sprite;
	public BuffType buffType;
	public BuffReceiver receiver;
	public bool isActivated = false;
	public UnityEvent EventOnActivate;
	public UnityEvent EventOnActivated;
	public virtual void Start()
	{
		receiver = GetComponent<BuffReceiver>();
	}
	public virtual void Activate(BuffReceiver receiver) 
	{ 
		isActivated = !isActivated;
		EventOnActivated.Invoke(); 
	}	
}
