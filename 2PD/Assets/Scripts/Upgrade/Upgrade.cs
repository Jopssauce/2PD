using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour 
{
	interface IUpgradeable<T>
	{
		void Upgrade(int amt);
		void Upgrade();
	}
	
}
