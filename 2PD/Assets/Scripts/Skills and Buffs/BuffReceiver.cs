using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuffReceiver : MonoBehaviour {
	public List<BaseBuff> buffs;
	public BuffReceiver instance;
	// Use this for initialization
	void Start () {
		instance = this;
	}
	

	public void AddBuff(BaseBuff buff)
	{
		BaseBuff temp = Instantiate(buff);
		buffs.Add(temp);
		temp.Activate(ref instance);
	}

}
