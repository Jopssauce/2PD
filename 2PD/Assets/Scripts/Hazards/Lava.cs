using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Lava : MonoBehaviour {
	public BaseBuff buff;
	
	public void OnTriggerStay2D(Collider2D col)
	{
		if(buff == null) return;
		BuffReceiver receiver = col.gameObject.GetComponent<BuffReceiver>();
		if(receiver == null) return;

		if (receiver.buffs.Any(p => p.ID == buff.ID) == false)
		{
			receiver.AddBuff(buff);
		}
		
	}
}
