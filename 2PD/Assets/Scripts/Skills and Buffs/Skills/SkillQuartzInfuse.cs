using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillQuartzInfuse : BaseSkill 
{
	BuffQuartzInfuse buff;
	public override void Activate(GameObject actor, GameObject target)
	{
		if (target.GetComponent<BuffReceiver>())
		{
			BuffReceiver receiver = target.GetComponent<BuffReceiver>();
			receiver.AddBuff(buff);
		}
	}	

}
