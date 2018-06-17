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
	

	public BaseBuff AddBuff(BaseBuff buff)
	{
		BaseBuff temp = Instantiate(buff, this.transform);
		buffs.Add(temp);
		temp.Activate(this);
		return temp;
	}

	public void RemoveBuff(BaseBuff buff)
	{
		BaseBuff temp = buff;
		Destroy(temp.gameObject);
		buffs.Remove(temp);	
	}

}
