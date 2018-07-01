using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
public class HealingAura : MonoBehaviour 
{
	public bool isActivated;
	public BaseBuff buff;
	public List<PlayerController> players;
	public UnityEvent EventOnActivate;
	public UnityEvent EventOnDeactivate;

	void LateUpdate()
	{
		if(isActivated == false) return; 
		foreach (var item in players)
		{
			BuffReceiver receiver = item.GetComponent<BuffReceiver>();
			if (receiver.buffs.Any(p => p.buffType == buff.buffType) == true)
			{
				return;
			}
			if (receiver.buffs.Any(p => p.ID == buff.ID) == false)
			{
				receiver.AddBuff(buff);
			}
		}
	}

	public virtual void OnTriggerEnter2D(Collider2D col)
	{
		BuffReceiver receiver = col.GetComponent<BuffReceiver>();
		if(receiver == null) return;
		players.Add(receiver.GetComponent<PlayerController>());
		
	}

	public virtual void OnTriggerExit2D(Collider2D col)
	{
		BuffReceiver receiver = col.GetComponent<BuffReceiver>();
		if(receiver == null) return;
		if (col.gameObject.tag == "Player" && players.Any(player => player.ID == col.gameObject.GetComponent<PlayerController>().ID))
		{
			players.Remove(col.gameObject.GetComponent<PlayerController>());
		}
		
	}

	public virtual void Activate()
	{
		isActivated = true;
		EventOnActivate.Invoke();
	}

	public virtual void Deactivate()
	{
		isActivated = false;
		EventOnDeactivate.Invoke();
	}
	
	
}
