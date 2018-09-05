using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class ArcherCombat : PlayerCombat 
{
		public override void Attack()
    {
			base.Attack();
			Debug.Log("projectile");
    }

		public override void CmdSpawnAttackPrefab(GameObject obj)
	{
		Vector3 pos = transform.position + playercontroller.direction * offset;
		GameObject bullet = Instantiate(obj, pos, obj.transform.rotation);
		ChangeRotation(bullet);
		bullet.GetComponent<BulletBehaviour>().direction = playercontroller.direction;
		bullet.GetComponent<BulletBehaviour>().damage = damage;
		//NetworkServer.Spawn(bullet);
	}
	
}
