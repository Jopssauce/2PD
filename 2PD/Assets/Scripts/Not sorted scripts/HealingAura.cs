using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class HealingAura : MonoBehaviour 
{
	public BaseBuff buff;

	public virtual void OnTriggerEnter2D(Collider2D col)
	{
		BuffReceiver receiver = col.GetComponent<BuffReceiver>();
		if(receiver == null) return;
		if (receiver.buffs.Any(item => item.buffType == buff.buffType) == true)
		{
			return;
		}
		if (receiver.buffs.Any(item => item.ID == buff.ID) == false)
		{
				receiver.AddBuff(buff);
		}
	}
	
}
