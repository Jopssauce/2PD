using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour 
{
	public float damage;
	void Start()
	{
		Destroy(this.gameObject, 0.1f);
	}
	
	public void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log(col);
		if(col.gameObject.GetComponent<PlayerStats>())
		{
			col.gameObject.GetComponent<PlayerStats>().DeductHp(damage);
		}
		
	}
}
