using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumberAnimator : MonoBehaviour {
	Animator anim;
	public float duration;
	public float speed = 2;
	IEnumerator floatAnim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	public void StartAnim()
	{
		floatAnim = Animation();
		StartCoroutine(floatAnim);
	}

	public void FixedUpdate()
	{
		transform.position += transform.up * Time.deltaTime * speed;
	}

	public void DestroySelf()
	{
		Destroy(this.gameObject);
	}

	public IEnumerator Animation()
	{
		yield return new WaitForSeconds(duration);
		DestroySelf();
	}
}
