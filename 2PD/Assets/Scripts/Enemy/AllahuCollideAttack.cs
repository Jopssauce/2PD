using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllahuCollideAttack : EnemyCollideAttack {
	public GameObject explosionPrefab;


	public  void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{	

				Instantiate (explosionPrefab, transform.position, explosionPrefab.transform.rotation);
				col.gameObject.GetComponent<Rigidbody2D>().AddForce(col.gameObject.GetComponent<PlayerController>().direction * 300, ForceMode2D.Force);
				Destroy (this.gameObject);
			

		}
		Debug.Log("collide");
	}

}
