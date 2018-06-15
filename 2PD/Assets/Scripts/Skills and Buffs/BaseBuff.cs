using System.Collections;
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
	BuffReceiver receiver;
	public bool isActivated;
	public UnityEvent EventOnActivate;
	public virtual void Start()
	{
		receiver = GetComponent<BuffReceiver>();
	}
	public virtual void Activate<T>(ref T receiver) { }	
}
