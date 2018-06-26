using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillActor : MonoBehaviour {
	public List<BaseSkill> skills;
	public Queue<BaseSkill> skillQueue;
	public BaseSkill currentSkill;
	public int index;
	public UnityEvent EventOnSkillForward;
	public UnityEvent EventOnSkillBackward;
	
	void Start()
	{
		skillQueue = new Queue<BaseSkill>();
		foreach (var item in skills)
		{
			BaseSkill temp = Instantiate(item, this.transform);
			skillQueue.Enqueue(temp);
		}
		currentSkill = skillQueue.Peek();
		EventOnSkillForward.AddListener(SkillForward);
		EventOnSkillBackward.AddListener(SkillBackward);
	}

	public void SkillForward()
	{
		if(skills.Count <= 0) return;
		index++;
		if(index > skills.Count - 1) index = 0;
		currentSkill = skills[index];
        UseSkill(this.gameObject);
	}
	public void SkillBackward()
	{
		if(skills.Count <= 0) return;
		index--;
		if(index < 0) index = skills.Count - 1;
		currentSkill = skills[index];
		UseSkill(this.gameObject);
	}

	public void UseSkill(GameObject target)
	{
		currentSkill.Activate(this.gameObject, target);
	}

	public void AddSkill(BaseSkill skill)
	{
		skills.Add(skill);
	}

}
