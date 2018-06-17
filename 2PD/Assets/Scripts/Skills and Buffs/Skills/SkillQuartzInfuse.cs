using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkillQuartzInfuse : BaseSkill 
{
	public BuffQuartzInfuse buff;
	public override void Activate(GameObject actor, GameObject target)
	{
		base.Activate(actor, target);
		if (target.GetComponent<BuffReceiver>())
		{
			BuffReceiver receiver = target.GetComponent<BuffReceiver>();
			if (receiver.buffs.First(item => item == buff) == true)
			{
				buff.Activate(receiver);
			}
			if (receiver.buffs.Any(item => item == buff) == false)
			{
				receiver.AddBuff(buff);
				buff.Activate(receiver);
			}
		}
	}	

}
