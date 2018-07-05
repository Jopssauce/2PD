using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : PlayerCombat {

	public override void Attack()
    {
		base.Attack();
		Debug.Log("melee");
    }

	public override void CmdSpawnAttackPrefab(GameObject obj)
	{
		GameObject bullet = Instantiate(obj, playercontroller.directions[playercontroller.lastDirection].transform.position, playercontroller.directions[playercontroller.lastDirection].transform.rotation, this.transform);
		bullet.GetComponent<MeleeAttack>().direction = playercontroller.direction;
		//NetworkServer.Spawn(bullet);
	}
}
