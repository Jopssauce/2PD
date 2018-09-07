using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCombat : MonoBehaviour
{
	public GameObject objPrefab;
	public PlayerController playercontroller;
	public float damage;
	public float attackSpeedModifier = 0;
	public float attackCooldown = 0.5f;
	public float offset = 0.2f;
	protected bool isAttackCooldownStarted = false;

	public UnityEvent EventAttacking;
	public UnityEvent EventAttacked;
	
	protected IEnumerator startAttackCooldown;
	public virtual void Start()
	{
		playercontroller = GetComponent<PlayerController>();
		playercontroller.EventOnAttack.AddListener(Attack);
	}
	public virtual void Attack()
    {
		if(!playercontroller.canCombat) return;
		EventAttacking.Invoke();
		CmdSpawnAttackPrefab(objPrefab);
		startAttackCooldown = StartAttackCooldown();
		StartCoroutine(startAttackCooldown);
    }

	//[Command]
	public virtual void CmdSpawnAttackPrefab(GameObject obj)
	{
		Vector3 pos = transform.position + playercontroller.direction * offset;
		GameObject bullet = Instantiate(obj, pos, obj.transform.rotation);
		ChangeRotation(bullet);
		//NetworkServer.Spawn(bullet);
	}

	public IEnumerator StartAttackCooldown()
	{
		playercontroller.canCombat = false;
		isAttackCooldownStarted = true;
		playercontroller.canMove = false;
		yield return new WaitForSeconds(GetAttackSpeed());
		playercontroller.canCombat = true;
		playercontroller.canMove = true;
		isAttackCooldownStarted = false;
		EventAttacked.Invoke();
	}

	public void ChangeRotation(GameObject obj)
	{
		if (playercontroller.direction.x == -1)
		{
			obj.transform.rotation = Quaternion.Euler(0,0, 90);
		}
		else if (playercontroller.direction.x == 1)
		{
			obj.transform.rotation = Quaternion.Euler(0,0, -90);
		}
		if (playercontroller.direction.y == -1)
		{
			obj.transform.rotation = Quaternion.Euler(0,0, -180);
		}
		if (playercontroller.direction.x == 1)
		{
			transform.rotation = Quaternion.Euler(0,0, 0);
		}
	}

	public float GetAttackSpeed()
	{
		float value = (attackSpeedModifier * attackCooldown) - attackCooldown;
		return Mathf.Abs (value);
	}
}
