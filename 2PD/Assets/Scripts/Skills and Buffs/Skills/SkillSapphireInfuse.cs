using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSapphireInfuse : BaseSkill 
{
    public BuffSapphireInfuse buff;
	public override void Activate(GameObject actor, GameObject target)
	{
		if (target.GetComponent<BuffReceiver>())
		{
			BuffReceiver receiver = target.GetComponent<BuffReceiver>();
			receiver.AddBuff(buff);
		}
	}	

}