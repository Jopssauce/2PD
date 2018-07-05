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
			EventAttacked.Invoke();
    }

		public override void CmdSpawnAttackPrefab(GameObject obj)
	{
		GameObject bullet = Instantiate(obj, playercontroller.directions[playercontroller.lastDirection].transform.position, playercontroller.directions[playercontroller.lastDirection].transform.rotation);
		bullet.GetComponent<BulletBehaviour>().direction = playercontroller.direction;
		//NetworkServer.Spawn(bullet);
	}
	
}
