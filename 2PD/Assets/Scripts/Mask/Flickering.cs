using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickering : MonoBehaviour {
	public float flickInterval;
	[Range(0.0f, 1.0f)]
	public float flickSize;
	IEnumerator flicker;
	Vector3 prevScale;
	Vector3 newScale;


	void OnEnable()
	{
		flicker = Flicker();
		StartCoroutine(flicker);
	}


	public IEnumerator Flicker()
	{
		while (true)
		{
			yield return new WaitForSeconds(flickInterval);
			prevScale = transform.localScale;
			newScale = new Vector3(transform.localScale.x + flickSize, transform.localScale.x + flickSize , 1);
			transform.localScale = newScale;
			yield return new WaitForSeconds(flickInterval);
			transform.localScale = prevScale;
		}
		
	}
}
