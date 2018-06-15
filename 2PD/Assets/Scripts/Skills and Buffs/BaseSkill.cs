using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseSkill : MonoBehaviour 
{
	public enum SkillType
	{
		buff,
		attack
	}
	public UnityEvent EventOnActivate;
	public virtual void Activate<T>(ref T actor, ref T target) { }	
}
