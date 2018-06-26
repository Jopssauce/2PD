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
	SkillActor actor;
	public string ID;
	public UnityEvent EventOnActivate;

	public virtual void Start()
	{
		actor = GetComponent<SkillActor>();
	}

	public virtual void Activate(GameObject actor, GameObject target) {  }	
}
