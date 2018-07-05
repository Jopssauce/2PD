using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerCombat : MonoBehaviour 
{
	public GameObject objPrefab;
	public PlayerController playercontroller;
	public float attackCooldown = 0.5f;
	public bool canAttack = true;
	protected bool isAttackCooldownStarted = false;

	protected IEnumerator startAttackCooldown;
	public virtual void Start()
	{
		playercontroller = GetComponent<PlayerController>();
		playercontroller.EventOnAttack.AddListener(Attack);
	}
	public virtual void Attack()
    {
		if(!canAttack) return;
		CmdSpawnAttackPrefab(objPrefab);
		startAttackCooldown = StartAttackCooldown();
		StartCoroutine(startAttackCooldown);
    }

	//[Command]
	public virtual void CmdSpawnAttackPrefab(GameObject obj)
	{
		GameObject bullet = Instantiate(obj, playercontroller.directions[playercontroller.lastDirection].transform.position, playercontroller.directions[playercontroller.lastDirection].transform.rotation);
		//NetworkServer.Spawn(bullet);
	}

	public IEnumerator StartAttackCooldown()
	{
		canAttack = false;
		isAttackCooldownStarted = true;
		yield return new WaitForSeconds(attackCooldown);
		canAttack = true;
		isAttackCooldownStarted = false;
	}
}
