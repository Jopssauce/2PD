using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerCombat : MonoBehaviour 
{
	public GameObject objPrefab;
	public PlayerController playercontroller;
	public virtual void Start()
	{
		playercontroller = GetComponent<PlayerController>();
		playercontroller.EventOnAttack.AddListener(Attack);
	}
	public virtual void Attack()
    {

    }

	//[Command]
	public virtual void CmdSpawnObject(GameObject obj)
	{
		GameObject bullet = Instantiate(obj, playercontroller.directions[playercontroller.lastDirection].transform.position, playercontroller.directions[playercontroller.lastDirection].transform.rotation);
		//NetworkServer.Spawn(bullet);
	}
}
