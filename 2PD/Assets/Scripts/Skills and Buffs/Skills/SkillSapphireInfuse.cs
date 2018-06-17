using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkillSapphireInfuse : BaseSkill 
{
    public BuffSapphireInfuse buff;
	public override void Activate(GameObject actor, GameObject target)
	{
		base.Activate(actor, target);
		if (target.GetComponent<BuffReceiver>())
		{
			BuffReceiver receiver = target.GetComponent<BuffReceiver>();
			if (receiver.buffs.Any(item => item.buffType == buff.buffType) == true)
			{
				//BaseBuff temp = receiver.buffs.First(item => item.buffType == buff.buffType);
				foreach (var item in receiver.buffs.ToArray())
				{
					if (item.buffType == buff.buffType)
					{
						item.Activate(receiver);
						receiver.RemoveBuff(item);
					}
				}
				//temp.Activate(receiver);			
			}
			if (receiver.buffs.Any(item => item.ID == buff.ID) == false)
			{
				receiver.AddBuff(buff);
			}
		}
	}	

}