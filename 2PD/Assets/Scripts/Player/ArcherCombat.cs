using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class ArcherCombat : PlayerCombat 
{
 	public override void Attack()
    {
		CmdSpawnObject(objPrefab);
		Debug.Log("test");
    }
	
}
