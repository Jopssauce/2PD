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
	public bool isActivated;
	public UnityEvent EventOnActivate;
	public virtual void Activate<T>(ref T actor, ref T target) { }	
}
