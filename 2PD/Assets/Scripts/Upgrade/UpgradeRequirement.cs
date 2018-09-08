using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
public class UpgradeRequirement 
{
	//To be used in a serialized list
	public BaseItem item;
	public int amount;
	public bool isAcquired = false;
}
