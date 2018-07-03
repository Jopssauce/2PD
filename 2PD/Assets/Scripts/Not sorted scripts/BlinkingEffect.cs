using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlinkingEffect : MonoBehaviour 
{
	public float blinkInterval = 0.1f;
	public SpriteRenderer sr;
	Color prevColor;

	public UnityEvent EventActivate;
	public UnityEvent EventDeactivate;

	

	IEnumerator blink;

	void Start()
	{
		EventActivate.AddListener(Activate);
		EventDeactivate.AddListener(Deactivate);
	}

	public void Activate()
	{
		blink = Blinking();
		StartCoroutine(blink);
	}

	public void Deactivate()
	{
		StopAllCoroutines();
		sr.color = prevColor;
	}

	public IEnumerator Blinking()
	{
		while (true)
		{
			prevColor = sr.color;
			sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0);
			yield return new WaitForSeconds(blinkInterval);
			sr.color = prevColor;
			yield return new WaitForSeconds(blinkInterval);
		}
		
	}
	
}
