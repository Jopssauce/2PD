using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillActor : MonoBehaviour {
	public List<BaseSkill> skills;
	public Queue<BaseSkill> skillQueue;
	public BaseSkill currentSkill;

	public UnityEvent EventOnSwitchSkill;
	
	void Start()
	{
		skillQueue = new Queue<BaseSkill>();
		foreach (var item in skills)
		{
			BaseSkill temp = Instantiate(item, this.transform);
			skillQueue.Enqueue(temp);
		}
		currentSkill = skillQueue.Peek();
		EventOnSwitchSkill.AddListener(NextSkill);
	}

	public void NextSkill()
	{
		BaseSkill temp = skillQueue.Dequeue();
		currentSkill = skillQueue.Peek();
		skillQueue.Enqueue(temp);
	}

}
