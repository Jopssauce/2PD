using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlinkingEffect : MonoBehaviour 
{
	public float blinkInterval = 0.1f;

	public UnityEvent EventActivate;
	public UnityEvent EventDeactivate;

	public SpriteRenderer sr;

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
	}

	public IEnumerator Blinking()
	{
		while (true)
		{
			sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0);
			yield return new WaitForSeconds(blinkInterval);
			sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 255);
		}
		
	}
	
}
