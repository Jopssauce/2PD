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
		Vector3 pos = transform.position + playercontroller.direction * offset;
		GameObject bullet = Instantiate(obj, pos, obj.transform.rotation);
		ChangeRotation(bullet);
		bullet.GetComponent<MeleeAttack>().direction = playercontroller.direction;
		//NetworkServer.Spawn(bullet);
	}
}
