using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : PlayerCombat {

	public override void Attack()
    {
		CmdSpawnObject(objPrefab);
		Debug.Log("melee");
    }

	public override void CmdSpawnObject(GameObject obj)
	{
		GameObject bullet = Instantiate(obj, playercontroller.directions[playercontroller.lastDirection].transform.position, playercontroller.directions[playercontroller.lastDirection].transform.rotation, this.transform);
		bullet.GetComponent<MeleeAttack>().direction = playercontroller.direction;
		//NetworkServer.Spawn(bullet);
	}
}
