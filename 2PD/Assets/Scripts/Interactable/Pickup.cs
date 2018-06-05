using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Pickup : MonoBehaviour 
{
	public UnityEvent EventPickUp;
	public float Amount = 5;
	public Collider2D phyCollider;
	public GameManager gameManager;

	public virtual void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.GetComponent<PlayerController>())
		{
			col.gameObject.GetComponent<PlayerStats>().AddHp(Amount);
			EventPickUp.Invoke();
			Destroy(this.gameObject);
		}
		
	}

	public void EnableGravity()
	{
		phyCollider.GetComponent<Collider2D>().enabled = false;
		gameObject.layer = 9;
		PushInRandomDirection();
		GetComponent<Rigidbody2D>().gravityScale = Random.Range(0.1f,1.1f);
		StartCoroutine(DisableGravity());
	}

	IEnumerator DisableGravity()
	{
		yield return new WaitForSeconds(0.2f);
		gameObject.layer = 0;
		phyCollider.GetComponent<Collider2D>().enabled = true;
		GetComponent<Rigidbody2D>().gravityScale = 0.0f;
		GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		StopAllCoroutines();
	}

	public void PushInRandomDirection()
	{
		float direction = (Random.Range(-1f,2f));
		float force = Random.Range( 50f, 100f);
		Debug.Log(direction);
		GetComponent<Rigidbody2D>().AddForce(new Vector2(direction, 1) * force);
	}

}
